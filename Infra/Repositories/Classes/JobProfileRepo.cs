using Core;
using Infra.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Classes
{
    public class JobProfileRepo:GenericRepo<Job>,IJobProfileRepo
    {
        Context cntx;
        public JobProfileRepo(Context cntx):base(cntx)
        {
            this.cntx = cntx;
        }

        public List<Job> GetLatestJobs()
        {
            var res = this.cntx.Jobs.
                    Where(p => p.IsOpen == true).
                    OrderByDescending(p => p.CreatedDate);
             

            return res.ToList();
        }
    }
}
