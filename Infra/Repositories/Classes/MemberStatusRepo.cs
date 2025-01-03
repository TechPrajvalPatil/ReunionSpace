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
    public class MemberStatusRepo:IMemberStatusRepo
    {
        Context cntx;
        public MemberStatusRepo(Context cntx)
        {
            this.cntx = cntx;
        }


        public List<PendingMemberVM> GetActivatedList()
        {
            var res = from m in cntx.Members
                      join c in cntx.MemberCourseDets on m.MemberId equals c.MemberId
                      join r in cntx.MembersRequests on m.MemberId equals r.MemberId
                      where r.RequestStatus == RequestStatusEnum.Accepted &&
                      m.IsActive==true
                      select new PendingMemberVM
                      {
                          MemberId = m.MemberId,
                          MemberName = m.FullName,
                          MobileNo = m.MobileNo,
                          CourseName = c.CourseName,
                          AttendedYear = c.AttendedYear,
                      };

            return res.ToList();
        }

        public List<PendingMemberVM> GetDeActivatedList()
        {
            var res = from m in cntx.Members
                      join c in cntx.MemberCourseDets on m.MemberId equals c.MemberId
                      join r in cntx.MembersRequests on m.MemberId equals r.MemberId
                      where r.RequestStatus == RequestStatusEnum.Accepted &&
                      m.IsActive == false
                      select new PendingMemberVM
                      {
                          MemberId = m.MemberId,
                          MemberName = m.FullName,
                          MobileNo = m.MobileNo,
                          CourseName = c.CourseName,
                          AttendedYear = c.AttendedYear,
                      };

            return res.ToList();
        }

        public List<MemberConnectionVM> GetMemberConnectionsByMemberId(long memberId)
        {
            var res = from mc in cntx.MemberConnections
                      join mb in cntx.Members on mc.ConnectedMemberId equals mb.MemberId
                      where mc.MemberId == memberId
                      select new MemberConnectionVM
                      {
                          MemberId = mc.MemberId,
                          ConnectedMemberId = mc.ConnectedMemberId,
                          ConnectedMemberName = mb.FullName,
                          ProfilePicture = mb.ProfilePicture, 
                          Gender = mb.Gender,                  
                          AcceptDate = mc.AcceptDate
                      };

            return res.ToList();
        }

        public List<ResponseByMemberVM> GetPollResponsesByMemberId(long memberId)
        {
            var res = from pr in this.cntx.PollsResponses
                      where pr.MemberId == memberId
                      select new ResponseByMemberVM
                      {
                          PollQuestion = pr.Poll.PollQuestion,
                          SelectedOptions = pr.PollResponseOptions.Select(pro => pro.PollOption.Option).ToList()
                      };

            return res.ToList();
        }


        public void ActivateMember(long memberId)
        {
            var rec = this.cntx.Members.Find(memberId);

            rec.IsActive = true;
            this.cntx.Members.Update(rec);
            this.cntx.SaveChanges();
        }

        public void DeActivateMember(long memberId)
        {
            var rec = this.cntx.Members.Find(memberId);

            rec.IsActive = false;
            this.cntx.Members.Update(rec);
            this.cntx.SaveChanges();
        }
    }
}
