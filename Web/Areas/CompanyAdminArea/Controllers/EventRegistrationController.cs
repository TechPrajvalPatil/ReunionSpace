using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.CompanyAdminArea.Controllers
{
    [Area("CompanyAdminArea")]
    public class EventRegistrationController : Controller
    {
        IEventRegRepo erepo;
        public EventRegistrationController(IEventRegRepo erepo)
        {
            this.erepo = erepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AcceptRegistration(Int64 id)
        {
            this.erepo.AcceptedRegistration(id);
            TempData["success"] = "The event Registration Acccepted successfully!";
            return RedirectToAction("Index");
        }
    }
}
