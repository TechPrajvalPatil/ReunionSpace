using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class YourConnectionVC:ViewComponent
    {
        IConnectionRepo crepo;
        public YourConnectionVC(IConnectionRepo crepo)
        {
            this.crepo = crepo;
        }

        public IViewComponentResult Invoke()
        {
            var memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));
            var areq = this.crepo.GetYourConnection(memberId);
            return View(areq);
        }
    }
}
