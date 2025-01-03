using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("PollOptionTbl")]
    public class PollOption
    {
        [Key]
        public Int64 PollOptionId {  get; set; }
        public string Option {  get; set; }
        public bool IsCorrect {  get; set; }
        [ForeignKey("Poll")]
        public Int64 PollId {  get; set; }
        public virtual Poll Poll { get; set; }
        public virtual List<PollResponseOption> PollResponseOptions { get; set; }
    }
}
