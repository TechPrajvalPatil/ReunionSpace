using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class FeedsDetailsVM
    {
        public Int64 FeedsId { get; set; }
        public string FeedsTitle { get; set; }
        public DateTime FeedsDate { get; set; }
        public string FeedsDescription { get; set; }
        public string FeedType { get; set; }
        public string FeedStatus { get; set; }

        public List<string> PhotoPathFile { get; set; }

        
        public List<string> VideoUrl { get; set; }
    }
}
