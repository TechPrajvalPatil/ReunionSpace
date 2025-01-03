using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class MemberEducationVM
    {
        public Int64 MemberEducationId { get; set; }
        public Int64 MemberId { get; set; }
        public string EducationTitle { get; set; }
        public string PassoutYear { get; set; }
        public string UniversityOrCollegeName { get; set; }
        public string GradeOrPercentage { get; set; }
    }
}
