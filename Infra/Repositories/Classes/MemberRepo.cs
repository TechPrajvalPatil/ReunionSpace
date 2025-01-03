using Core;
using Infra.ViewModels;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.Classes
{
    public class MemberRepo : IMemberRepo
    {
        Context cntx;
        public MemberRepo(Context cntx)
        {
            this.cntx = cntx;
        }

        public void register(MemberRegisterVM rec)
        {
            var mb = new Member()
            {
                FirstName = rec.FirstName,
                LastName = rec.LastName,
                Address =rec.Address,
                Gender = rec.Gender,
                MobileNo = rec.MobileNo,
                EmailId = rec.EmailId,
                Password = rec.Password,
                CityId = rec.CityId,
                IsActive=true,
            };

            this.cntx.Members.Add(mb);
            

            var cr = new MemberCourseDet()
            {
                MemberId = mb.MemberId,
                CourseName = rec.CourseName,
                AttendedYear = rec.AttendedYear,
            };

            mb.MemberCourseDets.Add(cr);
           

            var req = new MemberRequest()
            {
                MemberId = mb.MemberId,
                RequestDate = DateTime.Now,
                RequestStatus = RequestStatusEnum.Pending
            };

            mb.MemberRequests.Add(req);

            this.cntx.Members.Add(mb);
            this.cntx.SaveChanges();
        }


        public LoginResultVM Login(LoginVM rec)
        {
            var res = this.cntx.MembersRequests
                .Where(p =>
                    p.MemberId == p.Member.MemberId &&
                    p.Member.EmailId == rec.EmailId &&
                    p.Member.Password == rec.Password)
                .Include(p=>p.Member)
                .SingleOrDefault();

            LoginResultVM log = new LoginResultVM();

            if (res != null)
            {
                if(!res.Member.IsActive)
                {
                    log.IsLoggedIn=false;
                    log.ErrorMessage = "You are Deactivated";
                }

                if (res.RequestStatus == RequestStatusEnum.Accepted)
                {
                    log.IsLoggedIn = true;
                    log.LoggedInId = res.MemberId;
                    log.LoggedName = res.Member.FullName;
                    log.LoggedEmailId = res.Member.EmailId;
                }
                else if (res.RequestStatus == RequestStatusEnum.Pending)
                {
                    log.IsLoggedIn = false;
                    log.ErrorMessage = "Your membership request is still pending approval.";
                }
                else if (res.RequestStatus == RequestStatusEnum.Rejected)
                {
                    log.IsLoggedIn = false;
                    log.ErrorMessage = "Your membership request was rejected. Please contact support.";
                }
            }
            else
            {
                log.IsLoggedIn = false;
                log.ErrorMessage = "Invalid Email ID or Password.";
            }

            return log;
        }
        public LoginVM GetCredentialsByEmail(string emailId)
        {
            var res = this.cntx.Members
                      .Where(m => m.EmailId == emailId)
                       .Select(m => new LoginVM
                       {
                           EmailId = m.EmailId,
                           Password = m.Password
                       });


            return res.SingleOrDefault();
        }


        public MemberRequest GetMemberRequestStatusByEmail(string emailId)
        {
            return this.cntx.MembersRequests
                .Where(p => p.Member.EmailId == emailId)
                .SingleOrDefault();
        }

        public RepoResultVM ChangePassword(ChangePasswordVM rec, long MemberId)
        {
            var mrec = this.cntx.Members.Find(MemberId);

            RepoResultVM res = new RepoResultVM();
            if(mrec.Password == rec.OldPassword)
            {
                mrec.Password = rec.NewPassword;
                this.cntx.SaveChanges();
                res.IsSuccess = true;
                res.Message = "Your Password Successfully Changed!";
            }
            else
            {
                res.IsSuccess = false;
                res.Message = "Invalid Old Password!";
            }

            return res;
        }

        public RepoResultVM EditProfile(MemberProfileVM rec, long MemberId)
        {
            var mrec = this.cntx.Members.Find(MemberId);
            RepoResultVM res = new RepoResultVM();

            try
            {
                mrec.Address = rec.Address;
                mrec.MobileNo = rec.MobileNo;
                mrec.CityId = rec.CityId;
                mrec.DateOfBirth = rec.DateOfBirth;
                mrec.ProfilePicture = rec.ProfilePicture;

                this.cntx.SaveChanges();
                res.IsSuccess = true;
                res.Message = "Profile Edited";
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }

            return res;

        }

        public MemberProfileVM GetMemberProfile(long MemberId)
        {
            var rec = from t in this.cntx.Members
                      where t.MemberId == MemberId
                      select new MemberProfileVM
                      {
                          FullName = t.FullName,
                          Address = t.Address,
                          MobileNo = t.MobileNo,
                          CityId = t.CityId,
                          DateOfBirth = t.DateOfBirth,
                          ProfilePicture = t.ProfilePicture,
                          EmailId = t.EmailId,
                          ProfileFile =t.ProfileFile,
                          Gender = t.Gender,
                      };

            return rec.FirstOrDefault();
        }
    }
}
