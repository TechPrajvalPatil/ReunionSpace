using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("PollResponseOptionTbl")]
    public class PollResponseOption
    {
        [Key]
        public Int64 PollResponseOptionId {  get; set; }
        [ForeignKey("PollResponse")]
        public Int64 PollResponseID { get; set; }
        public virtual PollResponse PollResponse { get; set; }
        [ForeignKey("PollOption")]
        public Int64 PollOptionId {  get; set; }
        public virtual PollOption PollOption { get; set; }
    }
}
