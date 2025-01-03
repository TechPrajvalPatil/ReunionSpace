using Core;
using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Interfaces
{
    public interface IProfileRepo:IGenericRepo<MemberEducation>
    {
        List<MemberEducation> GetMemberEducationByMemberId(long memberId);
        void AddMemberEducation(MemberEducation rec);
        void UpdateMemberEducation(MemberEducation rec);

        MemberExperience GetMemberExperienceId(long id);
        List<MemberExperience> GetMemberExperienceByMemberId(long memberId);
        void AddMemberExperience(MemberExperience rec);
        void UpdateMemberExperience(MemberExperience rec);


        List<MemberResume> GetMemberResumesByMemberId(long memberId);
        void AddResume(MemberResume rec, long memberId);
        void EditResume(MemberResume rec, long memberId);
        MemberResume GetResumeById(long id);


        RepoResultVM AddMemberSkills(MemberSkills rec, Int64[] chk, Int64 memberId);
        IEnumerable<MemberSkillVM> GetMemberSkills(Int64 memberId);
        RepoResultVM UpdateMemberSkills(IEnumerable<MemberSkills> skills);

    }
}
