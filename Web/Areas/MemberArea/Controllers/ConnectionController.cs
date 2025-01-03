using Core;
using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.CustFilters;

namespace Web.Areas.MemberArea.Controllers
{
    [MemberAuth]
    [Area("MemberArea")]
    public class ConnectionController : Controller
    {
        IConnectionRepo crepo;
        ICourseDetRepo cdrepo;
        public ConnectionController(IConnectionRepo crepo,ICourseDetRepo cdrepo)
        {
            this.crepo = crepo;
            this.cdrepo = cdrepo;
        }

        public IActionResult Index()
        {
            var memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));
            var res=this.crepo.GetAllMembers(memberId);

            return View(res);
        }

        [HttpPost]
        public IActionResult SearchByCourseYear(string courseName, string attendedYear)
        {
            var memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));

            
            var res = this.crepo.SearchMembersByCourseYear(courseName, attendedYear, memberId);

            
            return View("Index", res);
        }


        public IActionResult SendReq(Int64 reqid)
        {
            var mb = this.crepo.GetMemberById(reqid);
            return View(mb);
        }


        [HttpPost]
        public IActionResult SendReq(MemberReqVM rec)
        {
            
            var requestFromId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));

            this.crepo.SendConnectionRequest(requestFromId, rec.RequestToID, rec.RequestNote);
            TempData["success"] = "Request Sent Successfully!!";
            return RedirectToAction("Index");
        }


        public IActionResult PendingConReqDet(Int64 id)
        {
            var res = this.crepo.GetMemberDetById(id);
            return View(res);
        }

        public IActionResult RejectedConReqDet(Int64 id)
        {
            var res = this.crepo.GetMemberDetById(id);
            return View(res);
        }



        public IActionResult AcceptConReq(long id)
        {
            
            var memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));

            
            this.crepo.AcceptConnectionRequest(id, memberId);

            TempData["success"] = "Connection Request Accepted!";
            return RedirectToAction("Index");
        }

        public IActionResult RejectConReq(long id)
        {
            var memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));

            this.crepo.RejectConnectionRequest(id, memberId);

            TempData["success"] = "Connection Request Rejected!";
            return RedirectToAction("Index");
           
        }


    }
}
