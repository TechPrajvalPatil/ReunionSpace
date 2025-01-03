using Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class FeedsPhotoVideoVM
    {
        public Int64 FeedsId {  get; set; }
        public DateTime FeedDate { get; set; }
        public string FeedTitle {  get; set; }
        public FeedTypeEnum FeedType { get; set; }
        public string FeedsDescription { get; set; }
        [NotMapped]
        public IFormFile FileUpload { get; set; }
        public string PhotoPathFile { get; set; }
        public string VideoUrl { get; set; }
        public FeedStatusEnum FeedStatus { get; set; }
        public Int64 MemberId {  get; set; }

    }
}
