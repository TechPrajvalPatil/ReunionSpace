using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class EventRegVM
    {
        public Int64 EventId { get; set; }
        public string EventTitle { get; set; }
        public string EventShortDesc { get; set; }
        public DateTime EventDateTime { get; set; }
        public string EventLogo { get; set; }
        public DateTime RegistrationFromDate { get; set; }
        public DateTime RegistrationToDate { get; set; }
        public long MemberLimit { get; set; }
        public int RemainingSeats { get; set; }
        public bool IsMemberRegistered { get; set; }
    }
}
