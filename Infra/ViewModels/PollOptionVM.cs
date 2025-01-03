using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class PollOptionVM
    {
        public Int64 PollOptionId { get; set; }
        public string Option { get; set; }
        public bool IsSelected { get; set; }
    }
}
