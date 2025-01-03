using Core;
using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Classes
{
    public class EventRegRepo:IEventRegRepo
    {
        Context cntx;
        public EventRegRepo(Context cntx)
        {
            this.cntx = cntx;
        }


        public List<EventRegistration> NewRegistration()
        {
            return this.cntx.EventsRegistrations
                   .Where(p=>p.IsAccepted == false)
                   .OrderByDescending(p=>p.RegistrationDate)
                   .ToList();
        }



        public List<EventRegistration> AcceptedEventRegistration()
        {
           return this.cntx.EventsRegistrations
                  .Where(p=>p.IsAccepted == true)
                  .OrderByDescending(p => p.RegistrationDate)
                  .ToList();
        }

        public void AcceptedRegistration(long id)
        {
            var rec = this.cntx.EventsRegistrations.Find(id);
            if (rec != null)
            {
                rec.IsAccepted = true;
                this.cntx.Update(rec);
                this.cntx.SaveChanges();
            }
        }

        public List<MemberEventRegVM> MemberEventRegistrations(long id)
        {
            var res = from e in this.cntx.Events
                      join r in this.cntx.EventsRegistrations on e.EventId equals r.EventId
                      where r.MemberId == id
                      orderby r.RegistrationDate descending
                      select new MemberEventRegVM()
                      {
                          EventTitle = e.EventTitle,
                          EventDateTime = e.EventDateTime,
                          EventType = e.EventType,
                          EventMode = e.EventMode,
                          RegistrationDate = r.RegistrationDate,
                          IsAccepted = r.IsAccepted,
                          EventLogo = e.EventLogo,
                          EventShortDesc = e.EventShortDesc
                      };
            return res.ToList();
        }
    }
}
