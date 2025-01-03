using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Interfaces
{
    public interface IPendingMemberRepo
    {
        List<PendingMemberVM> GetPendingList();
        void AcceptedRequest(long id);
        void RejectedRequest(long id);
    }
}
