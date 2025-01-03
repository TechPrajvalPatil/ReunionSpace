using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Web.CustFilters;

namespace Web.Areas.MemberArea.Controllers
{
    [Area("MemberArea")]
    public class MemberHomeController : Controller
    {
        IMemberRepo mrepo;
        IWebHostEnvironment env;
        ICountryRepo crepo;
        IStateRepo srepo;
        ICityRepo ctrepo;

        public MemberHomeController(IMemberRepo mrepo, IWebHostEnvironment env, ICountryRepo crepo, IStateRepo srepo, ICityRepo ctrepo)
        {
            this.mrepo = mrepo;
            this.env = env;
            this.crepo = crepo;
            this.srepo = srepo;
            this.ctrepo = ctrepo;
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
                Int64 id = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));
                var res = this.mrepo.ChangePassword(rec,id);
               
                if(res.IsSuccess)
                {
                    TempData["success"]="Your Profile Password Changed!";
                }
                else
                {
                    ModelState.AddModelError("",res.Message);
                }
            }
            return View(rec);
        }


        public IActionResult EditProfile()
        {
            Int64 MemberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));
            var rec=this.mrepo.GetMemberProfile(MemberId);
            var city = this.ctrepo.GetById(rec.CityId);
            ViewBag.Countries = new SelectList(this.crepo.GetAll(), "CountryId", "CountryName", city.State.Country.CountryId);

            ViewBag.States = new SelectList(this.srepo.GetStateByCountryId(city.State.CountryId), "StateId", "StateName", city.State.StateId);

            ViewBag.Cities = new SelectList(this.ctrepo.GetCityByStates(city.StateId), "CityId", "CityName", rec.CityId);

            return View(rec);
        }


        [HttpPost]
        public IActionResult EditProfile(MemberProfileVM rec)
        {
            var city = this.ctrepo.GetById(rec.CityId);
            ViewBag.Countries = new SelectList(this.crepo.GetAll(), "CountryId", "CountryName", city.State.Country.CountryId);

            ViewBag.States = new SelectList(this.srepo.GetStateByCountryId(city.State.CountryId), "StateId", "StateName", city.State.StateId);

            ViewBag.Cities = new SelectList(this.ctrepo.GetCityByStates(city.StateId), "CityId", "CityName", rec.CityId);

            if (ModelState.IsValid)
            {
                try
                {
                    if (rec.ProfileFile != null)
                    {
                        if (rec.ProfileFile.Length > 0)
                        {
                            string folderpath = Path.Combine(env.WebRootPath, "ProfilePhoto");
                            string path = Path.Combine(folderpath, rec.ProfileFile.FileName);

                            FileStream fs = new FileStream(path, FileMode.Create);
                            rec.ProfileFile.CopyTo(fs);
                            rec.ProfilePicture = Path.Combine(@"\ProfilePhoto", rec.ProfileFile.FileName);
                        }
                        else
                        {
                            ModelState.AddModelError("ProfilePicture", "Please Select File having > 1 byte");
                            return View(rec);
                        }
                    }

                    Int64 MemberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));
                    this.mrepo.EditProfile(rec,MemberId);
                    TempData["success"] = "Profile Updated!!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("",ex.ToString());
                    return View(rec);
                }
            }

            return View(rec);
        }
    }
}
