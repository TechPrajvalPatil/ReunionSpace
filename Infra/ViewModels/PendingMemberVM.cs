using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class PendingMemberVM
    {
        public Int64 MemberId {  get; set; }
        public string MemberName {  get; set; }
        public string MobileNo {  get; set; }
        public string CourseName {  get; set; }
        public string AttendedYear {  get; set; }
        public Int64 MemberRequestId {  get; set; }
    }
}
