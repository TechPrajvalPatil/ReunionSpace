using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.CustFilters;

namespace Web.Areas.CompanyAdminArea.Controllers
{
    [CompanyAdminAuth]
    [Area("CompanyAdminArea")]
    public class PendingMembersController : Controller
    {
        IPendingMemberRepo prepo;
        public PendingMembersController(IPendingMemberRepo prepo)
        {
            this.prepo = prepo;
        }

        public IActionResult Index()
        {
            var res = this.prepo.GetPendingList();
            return View(res);
        }

        public IActionResult Accepted(Int64 id)
        {
            this.prepo.AcceptedRequest(id);
            TempData["success"] = "Member Request Accepted";
            return RedirectToAction("Index");
        }

        public IActionResult Rejected(Int64 id)
        {
            this.prepo.RejectedRequest(id);
            TempData["success"] = "Member Request Rejected";
            return RedirectToAction("Index");
        }
    }
}
