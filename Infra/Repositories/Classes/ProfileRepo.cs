using Core;
using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Infra.Repositories.Classes
{
    public class ProfileRepo : GenericRepo<MemberEducation>, IProfileRepo
    {
        Context cntx;
        public ProfileRepo(Context cntx) : base(cntx)
        {
            this.cntx = cntx;
        }

        public void AddMemberEducation(MemberEducation rec)
        {
            this.cntx.MemberEducations.Add(rec);
            this.cntx.SaveChanges();
        }



        public List<MemberEducation> GetMemberEducationByMemberId(long memberId)
        {
            var res = this.cntx.MemberEducations.
                    Where(p => p.MemberId == memberId);
            return res.ToList();
        }



        public void UpdateMemberEducation(MemberEducation rec)
        {
            var res = cntx.MemberEducations
                                        .FirstOrDefault(e => e.MemberEducationId == rec.MemberEducationId);
            if (res != null)
            {
                res.EducationTitle = rec.EducationTitle;
                res.PassoutYear = rec.PassoutYear;
                res.UniversityOrCollegeName = rec.UniversityOrCollegeName;
                res.GradeOrPercentage = rec.GradeOrPercentage;

                this.cntx.SaveChanges();
            }
        }


        public List<MemberExperience> GetMemberExperienceByMemberId(long memberId)
        {
            var res = this.cntx.MemberExperiences
.Where(p => p.MemberId == memberId);
            return res.ToList();
        }
        public void AddMemberExperience(MemberExperience rec)
        {
            this.cntx.MemberExperiences.Add(rec);
            this.cntx.SaveChanges();
        }
        public void UpdateMemberExperience(MemberExperience rec)
        {
            var res = cntx.MemberExperiences
                                         .FirstOrDefault(e => e.MemberExperienceId == rec.MemberExperienceId);
            if (res != null)
            {
                res.ExperienceTitle = rec.ExperienceTitle;
                res.ExperienceDuration = rec.ExperienceDuration;
                res.ExperienceDescription = rec.ExperienceDescription;
                res.CompanyName = rec.CompanyName;
                res.FromDate = rec.FromDate;
                res.ToDate = rec.ToDate;

                this.cntx.SaveChanges();
            }
        }

        public MemberExperience GetMemberExperienceId(long id)
        {
            return this.cntx.MemberExperiences.Find(id);
        }




        public List<MemberResume> GetMemberResumesByMemberId(long memberId)
        {
            return this.cntx.MemberResumes
                       .Where(r => r.MemberId == memberId)
                       .ToList();
        }


        public void AddResume(MemberResume rec, long memberId)
        {
            rec.MemberId = memberId;
            rec.LastUpadatedDate = DateTime.Now;

            cntx.MemberResumes.Add(rec);
            cntx.SaveChanges();
        }


        public void EditResume(MemberResume rec, long memberId)
        {
            var existingResume = this.cntx.MemberResumes
                .FirstOrDefault(r => r.MemberResumeId == rec.MemberResumeId && r.MemberId == memberId);

            if (existingResume != null)
            {
                existingResume.ResumeFilePath = rec.ResumeFilePath;
                existingResume.FileType = rec.FileType;
                existingResume.LastUpadatedDate = DateTime.Now;

                this.cntx.SaveChanges();
            }
        }


        public MemberResume GetResumeById(long id)
        {
            return this.cntx.MemberResumes.Find(id);
        }

        public RepoResultVM AddMemberSkills(MemberSkills rec, long[] chk, long memberId)
        {
            RepoResultVM res = new RepoResultVM();
            try
            {
                foreach (var temp in chk)
                {
                    // Check if the skill already exists for this member
                    var existingSkill = this.cntx.MemberSkills
                        .FirstOrDefault(ms => ms.MemberId == memberId && ms.SkillId == temp);

                    if (existingSkill != null)
                    {
                        // Update existing skill if proficiency or years have changed
                        existingSkill.Proficiency = rec.Proficiency;
                        existingSkill.NoOfYears = rec.NoOfYears;
                    }
                    else
                    {
                        // Add new skill if it doesn't already exist
                        MemberSkills ms = new MemberSkills
                        {
                            MemberId = memberId,
                            SkillId = temp,
                            Proficiency = rec.Proficiency,
                            NoOfYears = rec.NoOfYears
                        };
                        this.cntx.MemberSkills.Add(ms);
                    }
                }
                // Save changes after adding/updating all skills
                this.cntx.SaveChanges();

                res.IsSuccess = true;
                res.Message = "Skills Added/Updated Successfully!";
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }
            return res;
        }




        public IEnumerable<MemberSkillVM> GetMemberSkills(long memberId)
        {
            return (from ms in cntx.MemberSkills
                    join s in cntx.Skills on ms.SkillId equals s.SkillId
                    where ms.MemberId == memberId
                    select new MemberSkillVM
                    {
                        SkillName = s.SkillName,
                        Proficiency = ms.Proficiency,
                        NoOfYears = ms.NoOfYears
                    }).ToList();
        }

        public RepoResultVM UpdateMemberSkills(IEnumerable<MemberSkills> skills)
        {
            RepoResultVM res = new RepoResultVM();
            try
            {
                foreach (var skill in skills)
                {
                    var existingSkill = this.cntx.MemberSkills
                        .FirstOrDefault(ms => ms.MemberSkillsId == skill.MemberSkillsId);

                    if (existingSkill != null)
                    {
                        existingSkill.Proficiency = skill.Proficiency;
                        existingSkill.NoOfYears = skill.NoOfYears;
                    }
                }

                // Save changes after updating all skills
                this.cntx.SaveChanges();

                res.IsSuccess = true;
                res.Message = "Skills Updated Successfully!";
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }
            return res;
        }



    }
}
