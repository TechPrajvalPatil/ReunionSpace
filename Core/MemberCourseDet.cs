using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("MemberCourseDetTbl")]
    public class MemberCourseDet
    {
        [Key]
        public Int64 MemberCourseDetId {  get; set; }
        [ForeignKey("Member")]
        public Int64 MemberId {  get; set; }
        public virtual Member Member { get; set; }
        public string CourseName { get; set; }  
        public string AttendedYear { get; set; }
    }
}
