using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("AdminTbl")]
    public class Admin
    {
        [Key]
        public Int64 AdminId {  get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Address {  get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public string ContactNo {  get; set; }
        public string EmailId { get; set; }
        public string Password {  get; set; }
    }
}
