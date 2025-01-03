using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class MemberRegisterVM
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public GenderEnum Gender { get; set; }
        [Required]
        [RegularExpression(@"^\d{10}$")]
        public string MobileNo { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string AttendedYear { get; set; }
        [Required]
        public string Address {  get; set; }
        [Required]
        public Int64 CityId {  get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string EmailId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
