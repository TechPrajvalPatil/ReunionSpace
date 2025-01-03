using Infra.ViewModels;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Repositories.Interfaces;

namespace Infra.Repositories.Classes
{
    public class PendingMemberRepo : IPendingMemberRepo
    {
        Context cntx;
        public PendingMemberRepo(Context cntx)
        {
            this.cntx = cntx;
        }

        public List<PendingMemberVM> GetPendingList()
        {
            var res = from m in cntx.Members
                      join c in cntx.MemberCourseDets on m.MemberId equals c.MemberId
                      join r in cntx.MembersRequests on m.MemberId equals r.MemberId
                      where r.RequestStatus == RequestStatusEnum.Pending
                      select new PendingMemberVM
                      {
                          MemberName = m.FullName,
                          MobileNo = m.MobileNo,
                          CourseName = c.CourseName,
                          AttendedYear = c.AttendedYear,
                          MemberRequestId = r.MemberRequestId
                      };

            return res.ToList();

        }

        public void AcceptedRequest(long id)
        {
            var rec = this.cntx.MembersRequests.Find(id);
            if(rec != null)
            {
                rec.RequestStatus = RequestStatusEnum.Accepted;
                this.cntx.MembersRequests.Update(rec);
                this.cntx.SaveChanges();
            }
        }

        public void RejectedRequest(long id)
        {
            var rec = this.cntx.MembersRequests.Find(id);
            if (rec != null)
            {
                rec.RequestStatus = RequestStatusEnum.Rejected;
                this.cntx.MembersRequests.Update(rec);
                this.cntx.SaveChanges();
            }
        }
    }
}
