using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("MemberRequestTbl")]
    public class MemberRequest
    {
        [Key]
        public Int64 MemberRequestId {  get; set; }
        [ForeignKey("Member")]
        public Int64 MemberId { get; set; }
        public virtual Member Member { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestStatusEnum RequestStatus { get; set; }
        
    }
}
