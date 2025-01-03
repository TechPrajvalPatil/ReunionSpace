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
    public class StateRepo : GenericRepo<State>, IStateRepo
    {
        Context cntx;
        public StateRepo(Context cntx) : base(cntx)
        {
            this.cntx = cntx;
        }

        public List<StateVM> GetStateByCountryId(long CountryId)
        {
            var res = from t in cntx.States
                      where t.CountryId == CountryId
                      select new StateVM
                      {
                          StateId = t.StateId,
                          StateName = t.StateName
                      };

            return res.ToList();
        }
    }
}
