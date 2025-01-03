using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ManageCompanyAdminController : Controller
    {
        ICompanyAdminRepo carepo;
        public ManageCompanyAdminController(ICompanyAdminRepo carepo)
        {
            this.carepo = carepo;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM rec)
        {
            if(ModelState.IsValid)
            {
                var res= this.carepo.Login(rec);
                if(res.IsLoggedIn)
                {
                    HttpContext.Session.SetString("CompanyAdminId",res.LoggedInId.ToString());
                    HttpContext.Session.SetString("CompanyAdminName", res.LoggedName);
                    HttpContext.Session.SetString("CompanyAdminEmail", res.LoggedEmailId);

                    TempData["success"] = "You have successfully logged in!";
                    return RedirectToAction("Index", "CompanyAdminHome", new { area = "CompanyAdminArea" });
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
            TempData["success"] = "You have successfully logged out!";
            return RedirectToAction("Index", "Home");
        }
    }
}
