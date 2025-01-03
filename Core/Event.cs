using Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("EventTbl")]
    public class Event
    {
        [Key]
        public Int64 EventId {  get; set; }
        public string EventTitle {  get; set; }
        public string EventShortDesc { get; set; }
        public DateTime EventDateTime {  get; set; }
        [NotMapped]
        public IFormFile PhotoFile { get; set; }
        public string EventLogo { get; set; }
        public EventTypeEnum EventType { get; set; }
        public DateTime RegistrationFromDate {  get; set; }
        public DateTime RegistrationToDate { get; set; }
        public Int64 MemberLimit {  get; set; }
        public EventModeEnum EventMode { get; set; }
        [ForeignKey("CompanyAdmin")]
        public Int64 CreatedById {  get; set; }
        public virtual CompanyAdmin CompanyAdmin { get; set; }
        public virtual List<EventRegistration> EventRegistrations { get; set; }
    }
}
