using Core;
using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Interfaces
{
    public interface IEventRegRepo
    {
        List<EventRegistration> NewRegistration();
        List<EventRegistration> AcceptedEventRegistration();
        void AcceptedRegistration(long id);
        List<MemberEventRegVM> MemberEventRegistrations(long id);
    }
}
