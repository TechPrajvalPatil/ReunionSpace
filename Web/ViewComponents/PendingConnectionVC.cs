using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class PendingConnectionVC:ViewComponent
    {
        IConnectionRepo crepo;
        public PendingConnectionVC(IConnectionRepo crepo)
        {
            this.crepo = crepo;
        }

        public IViewComponentResult Invoke()
        {
            var memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));
            var preq= this.crepo.GetPendingConnectionRequests(memberId);
            return View(preq);
        }
    }
}
