using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.CompanyAdminArea.Controllers
{
    [Area("CompanyAdminArea")]
    public class ManageFeedsController : Controller
    {
        IManageFeedRepo frepo;
        public ManageFeedsController(IManageFeedRepo frepo)
        {
            this.frepo = frepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(Int64 id)
        {
            var res=this.frepo.GetFeedDetailsById(id);
            return View(res);
        }

        public IActionResult FeedAccept(Int64 id)
        {
            this.frepo.AcceptedFeed(id);
            TempData["success"] = "Member Feed Accepted!";
            return RedirectToAction("Index");
        }


        public IActionResult FeedReject(Int64 id)
        {
            this.frepo.RejectedFeed(id);
            TempData["success"] = "Member Feed Rejected!";
            return RedirectToAction("Index");
        }
    }
}
