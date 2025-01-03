using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class EventListVC:ViewComponent
    {
        IEventRepo erepo;
        public EventListVC(IEventRepo erepo)
        {
            this.erepo = erepo;
        }

        public IViewComponentResult Invoke()
        {
            var memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));
            var res = this.erepo.GetEvents(memberId);
            return View(res);
        }
    }
}
