using Core.Enums;
using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Classes
{
    public class AcceptedMemberRepo:IAcceptedMemberRepo
    {
        Context cntx;
        public AcceptedMemberRepo(Context cntx)
        {
            this.cntx = cntx;
        }

        public List<PendingMemberVM> GetAcceptedList()
        {
            var res = from m in cntx.Members
                      join c in cntx.MemberCourseDets on m.MemberId equals c.MemberId
                      join r in cntx.MembersRequests on m.MemberId equals r.MemberId
                      where r.RequestStatus == RequestStatusEnum.Accepted
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
