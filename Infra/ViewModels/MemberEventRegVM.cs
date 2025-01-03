using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class MemberEventRegVM
    {
        public string EventTitle {  get; set; }
        public DateTime EventDateTime { get; set; }
        public EventTypeEnum EventType { get; set; }
        public EventModeEnum EventMode { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsAccepted { get; set; }
        public string EventLogo { get; set; }
        public string EventShortDesc { get; set; }
    }
}
