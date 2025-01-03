using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Web.CustFilters;

namespace Web.Areas.AdminArea.Controllers
{
    [AdminAuth]
    [Area("AdminArea")]
    public class AdminHomeController : Controller
    {
        IAdminRepo arepo;
        public AdminHomeController(IAdminRepo arepo)
        {
            this.arepo = arepo;
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
            if(ModelState.IsValid)
            {
                Int64 id = Convert.ToInt64(HttpContext.Session.GetString("AdminId"));
                var res = this.arepo.ChangePassword(rec,id);
                ViewBag.Message=res.Message;
            }
            return View(rec);
        }


        public IActionResult EditProfile()
        {
            Int64 AdminId = Convert.ToInt64(HttpContext.Session.GetString("AdminId"));
            var rec= this.arepo.GetAdminProfile(AdminId);
            return View(rec);
        }


        [HttpPost]
        public IActionResult EditProfile(AdminProfileVM rec)
        {
            if(ModelState.IsValid)
            {
                Int64 AdminId = Convert.ToInt64(HttpContext.Session.GetString("AdminId"));

                var res = this.arepo.EditProfile(rec, AdminId);
                ViewBag.Message=res.Message;
            }

            return View(rec);
        }
    }
}
