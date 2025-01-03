using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("EventRegistrationTbl")]
    public class EventRegistration
    {
        [Key]
        public Int64 EventRegistrationId { get; set; }
        [ForeignKey("Member")]
        public Int64 MemberId {  get; set; }
        public virtual Member Member { get; set; }
        [ForeignKey("Event")]
        public Int64 EventId {  get; set; }
        public virtual Event Event { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsAccepted {  get; set; }
        [ForeignKey("CompanyAdmin")]
        public Int64 AcceptedById {  get; set; }
        public virtual CompanyAdmin CompanyAdmin { get; set; }

    }
}
