using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("MemberSkillsTbl")]
    public class MemberSkills
    {
        public Int64 MemberSkillsId { get; set; }
        public Int64 MemberId { get; set; }
        public Int64 SkillId { get; set; }
        public ProficiencyEnum Proficiency { get; set; }
        public int NoOfYears { get; set; }
    }
}
