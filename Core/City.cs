using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("CityTbl")]
    public class City
    {
        [Key]
        public Int64 CityId {  get; set; }
        public string CityName { get; set; }
        [ForeignKey("State")]
        public Int64 StateId {  get; set; }
        public virtual State State { get; set; }
        public virtual List<Company> Companies { get; set; }
        public virtual List<CompanyAdmin> CompanyAdmins { get; set; }
        public virtual List<Member> Members { get; set; }
    }
}
