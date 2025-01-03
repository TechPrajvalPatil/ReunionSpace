using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class PendingConnectionVM
    {
        public long MemberId { get; set; }
        public string FullName { get; set; }
        public string ProfilePicture { get; set; }
        public string RequestNote { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
