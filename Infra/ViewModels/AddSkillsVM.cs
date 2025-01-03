using Core;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Infra.ViewModels
{
    public class AddSkillsVM
    {
        public List<SelectListItem> AvailableSkills { get; set; }
        public List<long> SelectedSkillIds { get; set; }
        public Core.Enums.ProficiencyEnum Proficiency { get; set; }
        public int NoOfYears { get; set; }
    }
}
