using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("PollResponseTbl")]
    public class PollResponse
    {
        [Key]
        public Int64 PollResponseId {  get; set; }
        public DateTime PollResponseDate {  get; set; }
        [ForeignKey("Member")]
        public Int64 MemberId {  get; set; }
        public virtual Member Member { get; set; }
        [ForeignKey("Poll")]
        public Int64 PollId {  get; set; }
        public virtual Poll Poll { get; set; }
        public virtual List<PollResponseOption> PollResponseOptions { get; set; }


        public PollResponse()
        {
            PollResponseOptions = new List<PollResponseOption>();
        }

    }
}
