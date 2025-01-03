using Core;
using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Interfaces
{
    public interface IMemberRepo
    {
        void register(MemberRegisterVM rec);
        LoginResultVM Login(LoginVM rec);
        LoginVM GetCredentialsByEmail(string emailId);
        MemberRequest GetMemberRequestStatusByEmail(string emailId);
        RepoResultVM ChangePassword(ChangePasswordVM rec, Int64 MemberId);
        RepoResultVM EditProfile(MemberProfileVM rec, Int64 MemberId);
        MemberProfileVM GetMemberProfile(Int64 MemberId);

    }
}
