using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("CompanyTbl")]
    public class Company
    {
        [Key]
        public Int64 CompanyId {  get; set; }
        public string CompanyName {  get; set; }
        public string Address {  get; set; }
        public string EmailId {  get; set; }
        public string ContactNo {  get; set; }
        public string LogoPath {  get; set; }
        public DateTime RegistrationDate {  get; set; }
        [ForeignKey("City")]
        public Int64 CityId {  get; set; }
        public virtual City City { get; set; }
        public string WebsiteUrl { get; set; }
        public string ContactPersonName { get; set; }
        public virtual List<CompanyAdmin> CompanyAdmins { get; set;}
        
    }
}
