using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Classes
{
    public class AdminRepo : IAdminRepo
    {
        Context cntx;
        public AdminRepo(Context cntx)
        {
            this.cntx = cntx;
        }

        public RepoResultVM ChangePassword(ChangePasswordVM rec, long AdminId)
        {
            var arec = cntx.Admins.Find(AdminId);

            RepoResultVM res = new RepoResultVM();
            if (arec.Password == rec.OldPassword)
            {
                arec.Password = rec.NewPassword;
                cntx.SaveChanges();
                res.IsSuccess = true;
                res.Message = "Password Changed";
            }
            else
            {
                res.IsSuccess = false;
                res.Message = "Invalid Old Password";
            }

            return res;
        }

        public RepoResultVM EditProfile(AdminProfileVM rec, long AdminId)
        {
            var arec = cntx.Admins.Find(AdminId);
            RepoResultVM res = new RepoResultVM();

            try
            {
                arec.Address = rec.Address;
                arec.ContactNo = rec.ContactNo;
                arec.EmailId = rec.EmailId;

                cntx.SaveChanges();
                res.IsSuccess = true;
                res.Message = "Profile Edited!";
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }

            return res;
        }

        public AdminProfileVM GetAdminProfile(long AdminId)
        {
            var rec = from t in cntx.Admins
                      where t.AdminId == AdminId
                      select new AdminProfileVM
                      {
                          FullName = t.FirstName + " " + t.LastName,
                          Address = t.Address,
                          ContactNo = t.ContactNo,
                          EmailId = t.EmailId,
                      };

            return rec.FirstOrDefault();
        }

        public LoginResultVM Login(LoginVM rec)
        {
            LoginResultVM res = new LoginResultVM();
            var adminrec = cntx.Admins.SingleOrDefault(p => p.EmailId == rec.EmailId
                            && p.Password == rec.Password);

            if (adminrec != null)
            {
                res.IsLoggedIn = true;
                res.LoggedName = adminrec.FullName;
                res.LoggedInId = adminrec.AdminId;
                res.LoggedEmailId = adminrec.EmailId;
            }
            else
            {
                res.IsLoggedIn = false;
            }

            return res;
        }
    }
}
