using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.CompanyAdminArea.Controllers
{
    [Area("CompanyAdminArea")]
    public class AcceptedMembersController : Controller
    {
        IAcceptedMemberRepo arepo;
        public AcceptedMembersController(IAcceptedMemberRepo arepo)
        {
            this.arepo = arepo;
        }
        public IActionResult Index()
        {
            var res = this.arepo.GetAcceptedList();
            return View(res);
        }

        public IActionResult Rejected(Int64 id)
        {
            this.arepo.RejectedRequest(id);
            TempData["success"] = "Member Request Rejected";
            return RedirectToAction("Index");
        }
    }
}
