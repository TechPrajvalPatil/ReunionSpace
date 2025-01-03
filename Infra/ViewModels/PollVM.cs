using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class PollVM
    {
        public Int64 PollId {  get; set; }
        public DateTime PollDate {  get; set; }
        public string PollQuestion { get; set; }
        public bool IsResponded {  get; set; }
    }
}
