using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class RespondedPollVC:ViewComponent
    {
        IPollRepo prepo;
        public RespondedPollVC(IPollRepo prepo)
        {
            this.prepo = prepo;
        }

        public IViewComponentResult Invoke()
        {
            var memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));
            var res = this.prepo.GetRespondedPolls(memberId);
            return View(res);
        }
    }
}
