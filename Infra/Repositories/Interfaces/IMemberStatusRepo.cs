using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Interfaces
{
    public interface IMemberStatusRepo
    {
        List<PendingMemberVM> GetActivatedList();
        List<PendingMemberVM> GetDeActivatedList();
        List<MemberConnectionVM> GetMemberConnectionsByMemberId(Int64 memberId);
        List<ResponseByMemberVM> GetPollResponsesByMemberId(Int64 memberId);
        void DeActivateMember(long memberId);
        void ActivateMember(long memberId);
    }
}
