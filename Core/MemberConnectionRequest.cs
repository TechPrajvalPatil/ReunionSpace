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
    [Table("MemberConnectionRequestTbl")]
    public class MemberConnectionRequest
    {
        [Key]
        public Int64 MemberConnectionRequestId {  get; set; }
        public Int64 RequestFromID {  get; set; }
        public Int64 RequestToID { get; set;}
        public  DateTime RequestDate { get; set; }
        public RequestStatusEnum RequestStatus { get; set; }
        public string RequestNote {  get; set; }
        public virtual List<MemberConnection> MemberConnections { get; set; }
    }
}
