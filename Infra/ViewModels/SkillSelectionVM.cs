using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class SkillSelectionVM
    {
        public long SkillId { get; set; }
        public int NoOfYears { get; set; }
        public ProficiencyEnum Proficiency { get; set; }
    }
}
