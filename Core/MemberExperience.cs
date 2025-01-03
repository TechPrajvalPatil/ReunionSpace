using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("MemberExperienceTbl")]
    public class MemberExperience
    {
        [Key]
        public Int64 MemberExperienceId {  get; set; }
        [ForeignKey("Member")]
        public Int64 MemberId {  get; set; }
        public string ExperienceTitle {  get; set; }
        public double ExperienceDuration {  get; set; }
        public string ExperienceDescription { get; set; }
        public string CompanyName {  get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public virtual Member Member { get; set; }
    }
}
