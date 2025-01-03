using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ManageAdminController : Controller
    {
        IAdminRepo arepo;
        public ManageAdminController(IAdminRepo arepo)
        {
            this.arepo = arepo;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM rec)
        {
            if (ModelState.IsValid)
            {
                var res = this.arepo.Login(rec);
                if (res.IsLoggedIn)
                {
                    HttpContext.Session.SetString("AdminId", res.LoggedInId.ToString());
                    HttpContext.Session.SetString("AdminName", res.LoggedName);
                    HttpContext.Session.SetString("AdminEmail", res.LoggedEmailId);

                    return RedirectToAction("Index", "AdminHome", new { area = "AdminArea" });
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Email Id and Password");
                }
            }
            return View(rec);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
