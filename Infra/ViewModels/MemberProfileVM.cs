using Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class MemberProfileVM
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address {  get; set; }
        [Required]
        public GenderEnum Gender { get; set; }
        public Int64 CityId {  get; set; }
        public string DateOfBirth { get; set; }
        public IFormFile ProfileFile { get; set; }
        public string ProfilePicture { get; set; }
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile No should be in 10 digits")]
        public string MobileNo { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Id")]
        public string EmailId { get; set; }
    }
}
