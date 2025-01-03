using Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ViewModels
{
    public class EditFeedPhotoVideoVM
    {
        public long FeedsId { get; set; }
        public string FeedTitle { get; set; }
        public string FeedsDescription { get; set; }
        public FeedTypeEnum FeedType { get; set; }
        public IFormFile FileUpload { get; set; } 
        public string PhotoPathFile { get; set; }
        public string VideoUrl { get; set; }
    }
}
