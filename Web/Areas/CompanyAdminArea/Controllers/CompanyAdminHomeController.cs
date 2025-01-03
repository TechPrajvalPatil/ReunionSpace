using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Web.CustFilters;

namespace Web.Areas.CompanyAdminArea.Controllers
{
    [CompanyAdminAuth]
    [Area("CompanyAdminArea")]
    public class CompanyAdminHomeController : Controller
    {
        ICompanyAdminRepo carepo;
        public CompanyAdminHomeController(ICompanyAdminRepo carepo)
        {
            this.carepo = carepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }


        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordVM rec)
        {
            if (ModelState.IsValid)
            {
                Int64 id = Convert.ToInt64(HttpContext.Session.GetString("CompanyAdminId"));
                var res = this.carepo.ChangePassword(rec, id);
                TempData["success"] = "Password Changed Successfully";
            }
            return View(rec);
        }


        public IActionResult EditProfile()
        {
            Int64 CompanyAdminId = Convert.ToInt64(HttpContext.Session.GetString("CompanyAdminId"));
            var rec = this.carepo.GetAdminProfile(CompanyAdminId);
            return View(rec);
        }


        [HttpPost]
        public IActionResult EditProfile(AdminProfileVM rec)
        {
            if (ModelState.IsValid)
            {
                Int64 CompanyAdminId = Convert.ToInt64(HttpContext.Session.GetString("CompanyAdminId"));

                var res = this.carepo.EditProfile(rec, CompanyAdminId);
                TempData["success"] = "Profile Updated Successfully";
            }

            return View(rec);
        }
    }
}
