using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class RejectedConnectionVC:ViewComponent
    {
        IConnectionRepo crepo;
        public RejectedConnectionVC(IConnectionRepo crepo)
        {
            this.crepo = crepo;
        }

        public IViewComponentResult Invoke()
        {
            var memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));
            var res = this.crepo.GetRejectedConnectionRequests(memberId);
            return View(res);
        }
    }
}
