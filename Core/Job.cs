using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    [Table("JobTbl")]
    public class Job
    {
        [Key]
        public Int64 JobId {  get; set; }
        public string JobTitle {  get; set; }
        public string JobDescription { get; set; }
        public string MinimumEducation {  get; set; }
        public string Experience {  get; set; }
        public string JobRole {  get; set; }
        public bool IsOpen {  get; set; }
        public string CompanyName {  get; set; }
        public string ReferenceName {  get; set; }
        public string NoOfVacancies {  get; set; }
        public string AnyOtherInfo {  get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("CompanyAdmin")]
        public Int64 CompanyAdminId {  get; set; }
        public virtual CompanyAdmin CompanyAdmin { get; set; }
    }
}
