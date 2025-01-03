using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class MemberReqVM
    {
        public Int64 MemberId { get; set; }
        public string MemberName { get; set; }
        public string ProfilePicture { get; set; }
        public GenderEnum Gender { get; set; }
        public Int64 RequestFromID { get; set; }
        public Int64 RequestToID { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestStatusEnum RequestStatus { get; set; }
        public string RequestNote { get; set; }
    }
}
