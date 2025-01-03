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
    [Table("PollTbl")]
    public class Poll
    {
        [Key]
        public Int64 PollId {  get; set; }
        public DateTime PollDate { get; set; }
        public PollStatusEnum PollStatus { get; set; }
        public string PollQuestion {  get; set; }
        [ForeignKey("CompanyAdmin")]
        public Int64 CreatedById {  get; set; }
        public virtual CompanyAdmin CompanyAdmin { get; set; }
        public virtual List<PollResponse> PollResponses { get; set; }   
        public virtual List<PollOption> PollOptions { get; set; }
    }
}
