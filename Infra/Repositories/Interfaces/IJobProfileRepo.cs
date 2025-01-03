using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Interfaces
{
    public interface IJobProfileRepo:IGenericRepo<Job>
    {
        List<Job> GetLatestJobs();
    }
}
