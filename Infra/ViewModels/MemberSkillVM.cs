using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class MemberSkillVM
    {
        public Int64 MemberSkillId {  get; set; }
        public string SkillName { get; set; }
        public ProficiencyEnum Proficiency { get; set; }
        public int NoOfYears { get; set; }
    }
}
