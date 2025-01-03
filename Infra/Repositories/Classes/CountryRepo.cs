using Core;
using Infra.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Classes
{
    public class CountryRepo : GenericRepo<Country>, ICountryRepo
    {
        Context cntx;
        public CountryRepo(Context cntx) : base(cntx)
        {
            this.cntx = cntx;
        }
    }
}
