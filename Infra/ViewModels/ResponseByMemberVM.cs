using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class ResponseByMemberVM
    {
        public string PollQuestion { get; set; }
        public List<string> SelectedOptions { get; set; } = new List<string>();
    }
}
