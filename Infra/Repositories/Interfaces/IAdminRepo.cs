using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Interfaces
{
    public interface IAdminRepo
    {
        LoginResultVM Login(LoginVM rec);
        RepoResultVM ChangePassword(ChangePasswordVM rec, long AdminId);
        RepoResultVM EditProfile(AdminProfileVM rec, long AdminId);
        AdminProfileVM GetAdminProfile(long AdminId);
    }
}
