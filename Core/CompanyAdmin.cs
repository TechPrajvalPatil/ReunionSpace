using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("CompanyAdminTbl")]
    public class CompanyAdmin
    {
        [Key]
        public Int64 CompanyAdminId {  get; set; }
        [ForeignKey("Company")]
        public Int64 CompanyId {  get; set; }
        public virtual Company Company { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public string EmailId {  get; set; }
        public string MobileNo {  get; set; }
        public string Address {  get; set; }
        public string Password {  get; set; }
        [ForeignKey("City")]
        public Int64 CityId { get; set; }
        public virtual City City { get; set; }
        public virtual List<Event> Events { get; set; }
        public virtual List<Poll> Polls { get; set;}
        public virtual List<Job> Jobs { get; set; }
    }
}
