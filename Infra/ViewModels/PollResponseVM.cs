using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class PollResponseVM
    {
        public string PollQuestion { get; set; }
        public List<PollOptionVM> PollOptions { get; set; }
        public long PollOptionId { get; set; }
    }
}
