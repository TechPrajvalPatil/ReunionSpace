using Core.Enums;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class UpdateSkillVM
    {
        public Int64 MemberId {  get; set; }
        public long MemberSkillsId { get; set; }
        public long SkillId { get; set; }
        public int NoOfYears { get; set; }
        public ProficiencyEnum Proficiency { get; set; }
        public IEnumerable<Skill> AllSkills { get; set; }
    }
}
