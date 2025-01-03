using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class MemberPollResponseVM
    {
        public Int64 PollId {  get; set; }
        public string MemberName {  get; set; }
        public string Response {  get; set; }
        public string PollQuestion { get; set; }
        public DateTime PollResponseDate { get; set; }
    }
}
