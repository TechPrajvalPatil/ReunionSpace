using Core;
using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Classes
{
    public class CityRepo : GenericRepo<City>, ICityRepo
    {
        Context cntx;
        public CityRepo(Context cntx) : base(cntx)
        {
            this.cntx = cntx;
        }

        public List<CityVM> GetCityByStates(long StateId)
        {
            var res = from t in cntx.Cities
                      where t.StateId == StateId
                      select new CityVM
                      {
                          CityId = t.CityId,
                          CityName = t.CityName
                      };
            return res.ToList();
        }
    }
}
