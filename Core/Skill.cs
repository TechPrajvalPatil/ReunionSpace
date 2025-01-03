using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Skill
    {
        [Key]
        public Int64 SkillId { get; set; }
        public string SkillName { get; set; }
    }
}
