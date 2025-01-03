using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class PollListCountVM
    {
        public long PollId { get; set; }
        public DateTime PollDate { get; set; }
        public PollStatusEnum PollStatus { get; set; }
        public string PollQuestion { get; set; }
        public int ResponseCount { get; set; }
    }
}
