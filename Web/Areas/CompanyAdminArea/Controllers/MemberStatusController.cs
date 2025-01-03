using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.CompanyAdminArea.Controllers
{
    [Area("CompanyAdminArea")]
    public class MemberStatusController : Controller
    {
        IConnectionRepo crepo;
        IMemberStatusRepo srepo;
        public MemberStatusController(IConnectionRepo crepo,IMemberStatusRepo srepo)
        {
            this.crepo = crepo;
            this.srepo = srepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(Int64 id)
        {
            var res = this.crepo.GetMemberDetById(id);
            return View(res);
        }


        public IActionResult DeActive(Int64 memberId)
        {
            this.srepo.DeActivateMember(memberId);
            TempData["success"] = "Member has been deactivated. Access is no longer permitted.";
            return RedirectToAction("Index");
        }

        public IActionResult Active(Int64 memberId)
        {
            this.srepo.ActivateMember(memberId);
            TempData["success"] = "Member has been activated and can now log in.";
            return RedirectToAction("Index");
        }
    }
}
