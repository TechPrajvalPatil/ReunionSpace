using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.CustFilters;

namespace Web.Areas.MemberArea.Controllers
{
    [MemberAuth]
    [Area("MemberArea")]
    public class JobController : Controller
    {
        IJobProfileRepo jrepo;
        public JobController(IJobProfileRepo jrepo)
        {
            this.jrepo = jrepo;
        }
        public IActionResult Index()
        {
            var res = this.jrepo.GetLatestJobs();
            return View(res);
        }
    }
}
