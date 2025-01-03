using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.CustFilters;

namespace Web.Areas.MemberArea.Controllers
{
    [MemberAuth]
    [Area("MemberArea")]
    public class PollResponseController : Controller
    {
        IPollRepo prepo;
        public PollResponseController(IPollRepo prepo)
        {
            this.prepo = prepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ResponsePoll(Int64 id)
        {
            ViewBag.pollId = id;

            var res = this.prepo.GetPollsOptions(id);
            return View(res);
        }

        [HttpPost]
        public IActionResult ResponsePoll(Int64 pollId, Int64 pollOptionId)
        {
            var memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));
            this.prepo.SavePollResponse(memberId, pollId, pollOptionId);

            TempData["success"] = "Your Response Submitted Successfully";
            return RedirectToAction("Index");
        }

        public IActionResult ShowResponse(Int64 id)
        {
            var memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));

            ViewBag.pollId = id;
            var res = this.prepo.GetPollDetails(id, memberId);
            return View(res);
        }

        [HttpPost]
        public IActionResult UpdateResponse(Int64 pollId,Int64 pollOptionId)
        {
            Int64 memberId= Convert.ToInt64(HttpContext.Session.GetString("MemberId"));

            this.prepo.UpdatePollResponse(memberId,pollId, pollOptionId);
            TempData["success"] = "Your Response Updated Successfully";
            return RedirectToAction("Index");
        }
    }
}
