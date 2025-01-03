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
    [Table("FeedsVideo")]
    public class FeedsVideo
    {
        [Key]
        public Int64 FeedsVideoId {  get; set; }
        [ForeignKey("Feeds")]
        public Int64 FeedsId {  get; set; }
        public virtual Feeds Feeds {  get; set; }
        [NotMapped]
        public IFormFile VideoFile { get; set; }
        public string VideoUrl {  get; set; }

    }
}
