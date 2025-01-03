using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class ResponsePollVM
    {
        public string PollQuestion {  get; set; }
        public Int64 PollOptionId {  get; set; }
        public string Option {  get; set; }
    }
}
