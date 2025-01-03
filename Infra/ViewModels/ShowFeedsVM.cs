using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class ShowFeedsVM
    {
        public long FeedsId { get; set; }
        public string FeedsTitle { get; set; }
        public string FeedsDescription { get; set; }
        public DateTime FeedsDate { get; set; }
        public string MemberName { get; set; }
        public List<string> PhotoPathFile { get; set; } //
        public List<string> VideoUrl { get; set; }    
        public FeedTypeEnum FeedType { get; set; }
    }
}
