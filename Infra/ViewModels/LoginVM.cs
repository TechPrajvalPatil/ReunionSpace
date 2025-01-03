using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class LoginVM
    {
        [Required]
        [EmailAddress(ErrorMessage ="Email Id is Invalid")]
        public string EmailId {  get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password {  get; set; }
    }
}
