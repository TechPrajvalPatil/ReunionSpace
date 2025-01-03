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
    [Table("MemberResumeTbl")]
    public class MemberResume
    {
        [Key]
        public Int64 MemberResumeId { get; set; }
        [ForeignKey("Member")]
        public Int64 MemberId { get; set; }
        [NotMapped]
        public IFormFile ResumeFile { get; set; }
        public string ResumeFilePath { get; set; }
        public string FileType {  get; set; }
        public DateTime LastUpadatedDate { get; set; }

        public virtual Member Member { get; set; }
    }
}
