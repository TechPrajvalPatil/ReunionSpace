using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class OpenPollsVC:ViewComponent
    {
        IPollRepo prepo;
        public OpenPollsVC(IPollRepo prepo)
        {
            this.prepo = prepo;
        }

        public IViewComponentResult Invoke()
        {
            var memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));
            var res = this.prepo.GetNewOpenPolls(memberId);
            return View(res);
        }
    }
}
