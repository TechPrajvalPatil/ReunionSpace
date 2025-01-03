using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class AdminProfileVM
    {
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^\d{10}$",ErrorMessage ="Contact No should be in 10 digits")]
        public string ContactNo { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Invalid Email Id")]
        public string EmailId { get; set; }
    }
}
