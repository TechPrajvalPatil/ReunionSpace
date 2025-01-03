using Core;
using Core.Enums;
using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Classes
{
    public class ConnectionRepo:GenericRepo<Member>,IConnectionRepo
    {
        Context cntx;
        public ConnectionRepo(Context cntx):base(cntx)
        {
            this.cntx = cntx;
        }

        public List<MemberCourseVM> GetAllMembers(long memberId)
        {
            var requestedMemberIds = this.cntx.MemberConnectionsRequest
                .Where(r => (r.RequestFromID == memberId || r.RequestToID == memberId))
                .Select(r => r.RequestFromID == memberId ? r.RequestToID : r.RequestFromID)
                .ToList();

            var acceptedMemberIds = this.cntx.MembersRequests
                     .Where(r => r.RequestStatus == RequestStatusEnum.Accepted)
                     .Select(r => r.MemberId)
                     .Distinct()
                     .ToList();


            var members = this.cntx.Members
                .Where(m => acceptedMemberIds.Contains(m.MemberId) 
                            && !requestedMemberIds.Contains(m.MemberId) 
                            && m.MemberId != memberId) 
                .ToList();

            return members.Select(m => new MemberCourseVM
            {
                MemberId = m.MemberId,
                FullName = m.FullName,
                DateOfBirth = m.DateOfBirth,
                Gender = m.Gender,
                ProfilePicture = m.ProfilePicture,
                Age = CalculateAge(m.DateOfBirth)
            }).ToList();
        }





        private int CalculateAge(string DateOfBirth)
        {
            if(string.IsNullOrEmpty(DateOfBirth) || DateOfBirth == "0001-01-01")
    {
                return 0;
            }

            try
            {
                var birthDate = Convert.ToDateTime(DateOfBirth);
                var today = DateTime.Today;
                var age = today.Year - birthDate.Year;

                if (birthDate.Date > today.AddYears(-age))
                {
                    age--;
                }

                return age;
            }
            catch
            {
                return 0;
            }
        }



        public List<MemberCourseVM> SearchMembersByCourseYear(string courseName, string attendedYear, long memberId)
        {
            var requestedMemberIds = this.cntx.MemberConnectionsRequest
                .Where(r => (r.RequestFromID == memberId || r.RequestToID == memberId))
                .Select(r => r.RequestFromID == memberId ? r.RequestToID : r.RequestFromID)
                .ToList();

            var acceptedReq = this.cntx.MembersRequests
                .Where(r => r.RequestStatus == RequestStatusEnum.Accepted)
                .Select(r => r.MemberId)
                .ToList();

            courseName = courseName?.Trim().ToLower();
            attendedYear = attendedYear?.Trim();

            var memberCourses = this.cntx.Members
                .Where(m => acceptedReq.Contains(m.MemberId) && m.MemberId != memberId && !requestedMemberIds.Contains(m.MemberId))
                .Join(this.cntx.MemberCourseDets,
                      m => m.MemberId,
                      mc => mc.MemberId,
                      (m, mc) => new { m, mc })
                .Where(x =>
                    (string.IsNullOrEmpty(courseName) || x.mc.CourseName.ToLower() == courseName) &&
                    (string.IsNullOrEmpty(attendedYear) || x.mc.AttendedYear == attendedYear))
                .ToList();

            var result = memberCourses.Select(x => new MemberCourseVM
            {
                MemberId = x.m.MemberId,
                FullName = x.m.FullName,
                DateOfBirth = x.m.DateOfBirth,
                Gender = x.m.Gender,
                ProfilePicture = x.m.ProfilePicture,
                Age = CalculateAge(x.m.DateOfBirth),
                CourseName = x.mc.CourseName,
                AttendedYear = x.mc.AttendedYear
            }).ToList();

            return result;
        }


        public MemberReqVM GetMemberById(long reqid)
        {
            var mb = this.cntx.Members
                  .Where(m => m.MemberId == reqid)
                  .Select(m => new MemberReqVM
                  {
                      MemberId = m.MemberId,
                      MemberName = m.FullName,
                      ProfilePicture=m.ProfilePicture,
                      Gender=m.Gender,
                  })
                  .FirstOrDefault();

            return mb;
        }

        public void SendConnectionRequest(long requestFromId, long requestToId, string requestNote)
        {
            var conReq = new MemberConnectionRequest
            {
                RequestFromID = requestFromId,  
                RequestToID = requestToId,  
                RequestDate = DateTime.Now,  
                RequestStatus = RequestStatusEnum.Pending,  
                RequestNote = requestNote 
            };

            this.cntx.MemberConnectionsRequest.Add(conReq);
            this.cntx.SaveChanges();
        }

        public List<PendingConnectionVM> GetPendingConnectionRequests(long memberId)
        {
            var pendingReq = this.cntx.MemberConnectionsRequest
                .Where(req => req.RequestToID == memberId && req.RequestStatus == RequestStatusEnum.Pending)
                .Join(this.cntx.Members,
                      req => req.RequestFromID,
                      mb => mb.MemberId,
                      (req, mb) => new PendingConnectionVM
                      {
                          MemberId = mb.MemberId,
                          FullName = mb.FullName,
                          ProfilePicture = mb.ProfilePicture,
                          RequestNote = req.RequestNote,
                          RequestDate = req.RequestDate
                      })
                .ToList();

            return pendingReq;
        }

        public Member GetMemberDetById(long memberId)
        {
            return this.cntx.Members.FirstOrDefault(p=> p.MemberId == memberId);    
        }

        public void AcceptConnectionRequest(long requestFromId, long requestToId)
        {
            var connectionReq = this.cntx.MemberConnectionsRequest
                .FirstOrDefault(req => req.RequestFromID == requestFromId && req.RequestToID == requestToId);

            if (connectionReq != null)
            {
                connectionReq.RequestStatus = RequestStatusEnum.Accepted;

                
                var connection1 = new MemberConnection
                {
                    MemberId = requestFromId,
                    ConnectedMemberId = requestToId,
                    ConnectionRequestId = connectionReq.MemberConnectionRequestId,
                    AcceptDate = DateTime.Now
                };

                var connection2 = new MemberConnection
                {
                    MemberId = requestToId,
                    ConnectedMemberId = requestFromId,
                    ConnectionRequestId = connectionReq.MemberConnectionRequestId,
                    AcceptDate = DateTime.Now
                };

                
                this.cntx.MemberConnections.Add(connection1);
                this.cntx.MemberConnections.Add(connection2);

                this.cntx.SaveChanges();
            }

        }

        public void RejectConnectionRequest(long requestFromId, long requestToId)
        {
            var connectionReq = this.cntx.MemberConnectionsRequest
                 .FirstOrDefault(req => req.RequestFromID == requestFromId && req.RequestToID == requestToId);

            if (connectionReq != null)
            {
                connectionReq.RequestStatus = RequestStatusEnum.Rejected;

                this.cntx.SaveChanges();
            }
        }


        public List<PendingConnectionVM> GetYourConnection(long memberId)
        {
            var connectedMembers = (
                from mc in this.cntx.MemberConnections
                join mb in this.cntx.Members
                    on (mc.MemberId == memberId ? mc.ConnectedMemberId : mc.MemberId) equals mb.MemberId
                where mc.MemberId == memberId || mc.ConnectedMemberId == memberId
                select new PendingConnectionVM
                {
                    MemberId = mb.MemberId,
                    FullName = mb.FullName,
                    ProfilePicture = mb.ProfilePicture
                }
            ).Distinct()  
            .ToList();

            return connectedMembers;
        }

        public List<PendingConnectionVM> GetRejectedConnectionRequests(long memberId)
        {
            var rejectReq = this.cntx.MemberConnectionsRequest
                .Where(req => req.RequestToID == memberId && req.RequestStatus == RequestStatusEnum.Rejected)
                .Join(this.cntx.Members,
                      req => req.RequestFromID,
                      mb => mb.MemberId,
                      (req, mb) => new PendingConnectionVM
                      {
                          MemberId = mb.MemberId,
                          FullName = mb.FullName,
                          ProfilePicture = mb.ProfilePicture,
                          RequestNote = req.RequestNote,
                          RequestDate = req.RequestDate
                      })
                .ToList();

            return rejectReq;
        }
    }
}
