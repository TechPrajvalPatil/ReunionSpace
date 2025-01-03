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
    [Table("FeedsTbl")]
    public class Feeds
    {
        [Key]
        public Int64 FeedsId {  get; set; }
        public DateTime FeedsDate { get; set; }
        public string FeedsTitle { get; set; }
        public FeedTypeEnum FeedType { get; set; }
        public string FeedsDescription {  get; set; }
        public FeedStatusEnum FeedStatus { get; set; }
        [ForeignKey("Member")]
        public Int64 MemberId { get; set; }
        public virtual Member Member { get; set; }
        public virtual List<FeedsPhoto> FeedsPhotos { get; set; }
        public virtual List<FeedsVideo> FeedsVideos { get; set; }


        public Feeds()
        {
            FeedsPhotos = new List<FeedsPhoto>();
            FeedsVideos = new List<FeedsVideo>();
        }
    }
}
