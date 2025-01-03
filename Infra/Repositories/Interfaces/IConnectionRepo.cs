using Core;
using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Interfaces
{
    public interface IConnectionRepo:IGenericRepo<Member>
    {
        List<MemberCourseVM> GetAllMembers(long memberId);
        List<MemberCourseVM> SearchMembersByCourseYear(string courseName, string attendedYear, long memberId);
        MemberReqVM GetMemberById(long reqid);
        void SendConnectionRequest(long requestFromId, long requestToId, string requestNote);
        List<PendingConnectionVM> GetPendingConnectionRequests(long memberId);
        Member GetMemberDetById(long memberId);
        void AcceptConnectionRequest(long requestFromId, long requestToId);
        void RejectConnectionRequest(long requestFromId, long requestToId);
        List<PendingConnectionVM> GetYourConnection(long memberId);
        List<PendingConnectionVM> GetRejectedConnectionRequests(long memberId);
    }
}
