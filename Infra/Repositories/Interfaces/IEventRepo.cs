using Core;
using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Interfaces
{
    public interface IEventRepo:IGenericRepo<Event>
    {
        List<Event> CurrentEvents();
        List<Event> ExpiredEvents();
        List<EventRegVM> GetEvents(long memberId);
        bool RegisterMemberForEvent(long eventId, long memberId);
        void DeleteEventWithRegistrations(long id);

    }
}
