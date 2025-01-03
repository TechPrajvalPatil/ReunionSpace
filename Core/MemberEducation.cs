using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("MemberEducationTbl")]
    public class MemberEducation
    {
        [Key]
        public Int64 MemberEducationId { get; set; }
        [ForeignKey("Member")]
        public Int64 MemberId {  get; set; }
        public string EducationTitle {  get; set; }
        public string PassoutYear {  get; set; }
        public string UniversityOrCollegeName {  get; set; }
        public string GradeOrPercentage {  get; set; }
        public virtual Member Member { get; set; }
    }
}
