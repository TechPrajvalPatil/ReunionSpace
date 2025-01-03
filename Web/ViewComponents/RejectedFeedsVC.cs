using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class RejectedFeedsVC:ViewComponent
    {
        IManageFeedRepo frepo;
        public RejectedFeedsVC(IManageFeedRepo frepo)
        {
            this.frepo = frepo;
        }

        public IViewComponentResult Invoke()
        {
            var res = this.frepo.GetRejectedFeeds();
            return View(res);
        }
    }
}
