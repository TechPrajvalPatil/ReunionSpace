using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class MemberCourseVM
    {
        public Int64 MemberId {  get; set; }
        public string FullName {  get; set; }
        public string DateOfBirth { get; set; }
        public GenderEnum Gender { get; set; }
        public string CourseName { get; set; }
        public string AttendedYear { get; set; }
        public string ProfilePicture { get; set; }
        public int Age {  get; set; }
        public RequestStatusEnum RequestStatus { get; set; }
    }
}
