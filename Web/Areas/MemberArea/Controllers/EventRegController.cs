using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.CustFilters;

namespace Web.Areas.MemberArea.Controllers
{
    [MemberAuth]
    [Area("MemberArea")]
    public class EventRegController : Controller
    {
        IEventRepo erepo;
        IEventRegRepo regrepo;
        public EventRegController(IEventRepo erepo, IEventRegRepo regrepo)
        {
            this.erepo = erepo;
            this.regrepo = regrepo;
        }

        [HttpPost]
        public IActionResult Registration(Int64 id)
        {


            long memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));

            
            bool registrationSuccess = erepo.RegisterMemberForEvent(id, memberId);

            
            if (registrationSuccess)
            {
                TempData["success"] = "You have successfully registered for the event!";
            }
            else
            {
                TempData["error"] = "Registration failed. You might already be registered, or the event is full.";
            }

            
            return RedirectToAction("Index", "MemberHome", new {area="MemberArea"});
        }

        public IActionResult MemberEventReg()
        {
            Int64 id = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));
            var res = this.regrepo.MemberEventRegistrations(id);
            return View(res);
        }
    }
}
