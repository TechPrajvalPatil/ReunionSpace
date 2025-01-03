using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Infra.ViewModels
{
    public class EditSkillVM
    {
        public string Proficiency { get; set; }
        public int NoOfYears { get; set; }
        public List<SelectListItem> AvailableSkills { get; set; }
        public List<int> SelectedSkills { get; set; }
    }
}
