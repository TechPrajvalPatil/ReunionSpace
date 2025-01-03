using Core;
using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Interfaces
{
    public interface ICompanyAdminRepo:IGenericRepo<CompanyAdmin>
    {
        LoginResultVM Login(LoginVM rec);
        RepoResultVM ChangePassword(ChangePasswordVM rec, long CompanyAdminId);
        RepoResultVM EditProfile(AdminProfileVM rec, long CompanyAdminId);
        AdminProfileVM GetAdminProfile(long CompanyAdminId);
    }
}
