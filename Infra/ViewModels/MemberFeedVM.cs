using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class MemberFeedsVM
    {
        public long MemberId { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string ProfilePicture { get; set; }
        public string Address {  get; set; }
        public string City { get; set; }
        public GenderEnum Gender { get; set; }
        public List<ShowFeedsVM> MemberFeeds { get; set; }


        public MemberFeedsVM()
        {
            MemberFeeds = new List<ShowFeedsVM>();
        }
    }
}
