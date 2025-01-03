using Core;
using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Classes
{
    public class EventRepo:GenericRepo<Event>,IEventRepo
    {
        Context cntx;
        public EventRepo(Context cntx):base(cntx)
        {
            this.cntx = cntx;
        }

        public List<Event> CurrentEvents()
        {
            DateTime today = DateTime.Now;
            
            return this.cntx.Events
                       .Where(e => e.RegistrationToDate >= today)
                       .OrderBy(p=>p.EventDateTime)
                       .ToList();
        }


        public List<Event> ExpiredEvents()
        {
            DateTime today = DateTime.Now;

            return this.cntx.Events
                       .Where(e => e.RegistrationToDate < today)
                       .ToList();
        }

        public List<EventRegVM> GetEvents(long memberId)
        {
            DateTime today =DateTime.Now;

            var eve = this.cntx.Events.
                     Include(p => p.EventRegistrations).
                     Where(p => p.RegistrationToDate >= today).
                     OrderBy(p=>p.RegistrationToDate).
                     Select(e => new EventRegVM
                     {
                         EventId = e.EventId,
                         EventTitle = e.EventTitle,
                         EventShortDesc = e.EventShortDesc,
                         EventDateTime = e.EventDateTime,
                         EventLogo = e.EventLogo,
                         RegistrationToDate = e.RegistrationToDate,
                         RegistrationFromDate = e.RegistrationFromDate,
                         MemberLimit = e.MemberLimit,
                         RemainingSeats = (int)(e.MemberLimit - e.EventRegistrations.Count),
                         IsMemberRegistered = e.EventRegistrations.Any(r => r.MemberId == memberId)
                     }

                     );

            return eve.ToList();
        }

        public bool RegisterMemberForEvent(long eventId, long memberId)
        {
            bool alreadyRegistered = this.cntx.EventsRegistrations
                .Any(p => p.EventId == eventId && p.MemberId == memberId);

            if (alreadyRegistered)
            {
                return false; 
            }

            
            var selectedEvent = this.cntx.Events.FirstOrDefault(e => e.EventId == eventId);

            if (selectedEvent == null || (selectedEvent.MemberLimit - selectedEvent.EventRegistrations.Count) <= 0)
            {
                return false; 
            }

            
            var eventReg = new EventRegistration
            {
                EventId = eventId,
                MemberId = memberId,
                RegistrationDate = System.DateTime.Now,
                IsAccepted = false, 
                AcceptedById = 1 
            };

            
            this.cntx.EventsRegistrations.Add(eventReg);
            this.cntx.SaveChanges();

            return true;
        }

        public void DeleteEventWithRegistrations(long id)
        {
            var res = this.cntx.Events.Include(e => e.EventRegistrations).FirstOrDefault(e => e.EventId == id);

            if (res != null)
            {
                this.cntx.EventsRegistrations.RemoveRange(res.EventRegistrations);

                this.cntx.Events.Remove(res);
                this.cntx.SaveChanges();
            }
        }

    }
}
