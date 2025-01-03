using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.CompanyAdminArea.Controllers
{
    [Area("CompanyAdminArea")]
    public class RejectedMembersController : Controller
    {
        IRejectedMemberRepo rrepo;
        public RejectedMembersController(IRejectedMemberRepo rrepo)
        {
            this.rrepo = rrepo;
        }

        public IActionResult Index()
        {
            var res=this.rrepo.GetRejectedList();
            return View(res);
        }

        public IActionResult Accepted(Int64 id)
        {
            this.rrepo.AcceptedRequest(id);
            TempData["success"] = "Member Request Accepted";
            return RedirectToAction("Index");
        }
    }
}
