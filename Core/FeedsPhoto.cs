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
    [Table("FeedsPhoto")]
    public class FeedsPhoto
    {
        [Key]
        public Int64 FeedsPhotoId { get; set; }
        [ForeignKey("Feeds")]
        public Int64 FeedsId {  get; set; }
        public virtual Feeds Feeds {  get; set; }
        [NotMapped]
        public IFormFile PhotoFile { get; set; }
        public string PhotoPathFile {  get; set; }
    }
}
