using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class FeedsListVC:ViewComponent
    {
        IFeedRepo frepo;
        public FeedsListVC(IFeedRepo frepo)
        {
            this.frepo= frepo;
        }

        public IViewComponentResult Invoke()
        {
            var memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));
            var res = this.frepo.GetFeedListByMember(memberId);
            return View(res);
        }
    }
}
