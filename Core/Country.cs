using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("CountryTbl")]
    public class Country
    {
        public Int64 CountryId {  get; set; }
        public string CountryName { get; set; }
        public virtual List<State> States { get; set; }
    }
}
