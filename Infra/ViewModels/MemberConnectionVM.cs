using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class MemberConnectionVM
    {
        public Int64 MemberId { get; set; }
        public Int64 ConnectedMemberId { get; set; }
        public string ConnectedMemberName { get; set; }
        public string ProfilePicture { get; set; }  
        public GenderEnum Gender { get; set; }  
        public DateTime AcceptDate { get; set; }
    }
}
