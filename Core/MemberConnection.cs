using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("MemberConnectionTbl")]
    public class MemberConnection
    {
        [Key]
        public Int64 MemberConnectionId { get; set; }
        [ForeignKey("Member")]
        public Int64 MemberId {  get; set; }
        public virtual Member Member { get; set; }
        public Int64 ConnectedMemberId { get; set; }
        [ForeignKey("ConnectionRequest")]
        public Int64 ConnectionRequestId {  get; set; }
        public virtual MemberConnectionRequest ConnectionRequest { get; set; }
        public DateTime AcceptDate { get; set; }
    }
}
