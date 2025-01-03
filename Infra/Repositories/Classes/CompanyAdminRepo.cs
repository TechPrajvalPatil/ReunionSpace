using Core;
using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Classes
{
    public class CompanyAdminRepo :GenericRepo<CompanyAdmin> ,ICompanyAdminRepo
    {
        Context cntx;
        public CompanyAdminRepo(Context cntx):base(cntx) 
        {
            this.cntx = cntx;
        }

        public RepoResultVM ChangePassword(ChangePasswordVM rec, long CompanyAdminId)
        {
            var carec = cntx.CompanyAdmins.Find(CompanyAdminId);

            RepoResultVM res = new RepoResultVM();
            if (carec.Password == rec.OldPassword)
            {
                carec.Password = rec.NewPassword;
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

        public RepoResultVM EditProfile(AdminProfileVM rec, long CompanyAdminId)
        {
            var carec = cntx.CompanyAdmins.Find(CompanyAdminId);
            RepoResultVM res = new RepoResultVM();

            try
            {
                carec.Address = rec.Address;
                carec.MobileNo = rec.ContactNo;
                carec.EmailId = rec.EmailId;

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

        public AdminProfileVM GetAdminProfile(long CompanyAdminId)
        {
            var rec = from t in cntx.CompanyAdmins
                      where t.CompanyAdminId == CompanyAdminId
                      select new AdminProfileVM
                      {
                          FullName = t.FirstName + " " + t.LastName,
                          Address = t.Address,
                          ContactNo = t.MobileNo,
                          EmailId = t.EmailId,
                      };

            return rec.FirstOrDefault();
        }

        public LoginResultVM Login(LoginVM rec)
        {
            LoginResultVM res = new LoginResultVM();
            var carec = cntx.CompanyAdmins.SingleOrDefault(p => p.EmailId == rec.EmailId
                        && p.Password == rec.Password);

            if (carec != null)
            {
                res.IsLoggedIn = true;
                res.LoggedName = carec.FullName;
                res.LoggedInId = carec.CompanyAdminId;
                res.LoggedEmailId = carec.EmailId;
            }
            else
            {
                res.IsLoggedIn = false;
            }

            return res;
        }
    }
}
