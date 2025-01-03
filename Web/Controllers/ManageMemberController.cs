using Core;
using Core.Enums;
using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
    public class ManageMemberController : Controller
    {
        IMemberRepo mrepo;
        IStateRepo srepo;
        ICountryRepo crepo;
        ICityRepo ctrepo;

        public ManageMemberController(IMemberRepo mrepo, IStateRepo srepo, ICountryRepo crepo, ICityRepo ctrepo)
        {
            this.mrepo = mrepo;
            this.srepo = srepo;
            this.crepo = crepo;
            this.ctrepo = ctrepo;
        }

        public JsonResult GetStatesByCountry(Int64 CountryId)
        {
            var res = this.srepo.GetStateByCountryId(CountryId);
            return Json(res);
        }

        public JsonResult GetCities(Int64 StateId)
        {
            var res= this.ctrepo.GetCityByStates(StateId);
            return Json(res);
        }

        public IActionResult Register()
        {
            return View();
        }


        public JsonResult GetCredentialsMembers(string email, string password)
        {
            var res = this.mrepo.GetCredentialsByEmail(email);

            if (res == null || res.Password != password)
            {
                return Json(new { success = false, error = "Invalid Email ID or Password." });
            }

            
            var memberRequest = this.mrepo.GetMemberRequestStatusByEmail(email);

            if (memberRequest == null)
            {
                return Json(new { success = false, error = "No membership request found for this user." });
            }

            if (!memberRequest.Member.IsActive)
            {
                return Json(new { success = false, error = "You are Deactivated." });
            }


            switch (memberRequest.RequestStatus)
            {
                case RequestStatusEnum.Accepted:
                    return Json(new { success = true, emailId = res.EmailId, requestStatus = memberRequest.RequestStatus });

                case RequestStatusEnum.Pending:
                    return Json(new { success = false, error = "Your request is still pending approval.", requestStatus = memberRequest.RequestStatus });

                case RequestStatusEnum.Rejected:
                    return Json(new { success = false, error = "Your request has been rejected.", requestStatus = memberRequest.RequestStatus });

                default:
                    return Json(new { success = false, error = "An unknown error occurred. Please contact support." });
            }
        }






        [HttpPost]
        public IActionResult Register(MemberRegisterVM rec)
        {
            ViewBag.states = new SelectList(this.srepo.GetAll(), "StateId", "StateName");
            ViewBag.Cities = new SelectList(this.ctrepo.GetAll(), "CityId", "CityName");
            if(ModelState.IsValid)
            {
                this.mrepo.register(rec);
                TempData["success"] = "You have Registered Successfully!";
                return RedirectToAction("Index", "MemberHome", new { area = "MemberArea" });
            }
            else
            {
                ModelState.AddModelError("", "Fill up correct Information");
            }

            return ViewComponent("MemberRegisterVC", new { rec });
        }


        

        [HttpPost]
        public IActionResult Login(LoginVM rec)
        {
            if(ModelState.IsValid)
            {
                var res = this.mrepo.Login(rec);
                if(res.IsLoggedIn)
                {
                    HttpContext.Session.SetString("MemberId",res.LoggedInId.ToString());
                    HttpContext.Session.SetString("MemberName", res.LoggedName);
                    HttpContext.Session.SetString("MemberEmail",res.LoggedEmailId);

                    TempData["success"] = "You have successfully logged in!";

                    return RedirectToAction("Index", "MemberHome", new { area = "MemberArea" });
                }
                else
                {
                    TempData["error"] = "Invalid Email Id or Password.";
                }
            }
            return ViewComponent("MemberLoginVC", new { rec });
        }


        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            TempData["success"] = "Logged Out Successfully!!";
            return RedirectToAction("Index", "MemberHome", new { area = "MemberArea" });
        }
    }
}
