using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class PendingFeedsVC:ViewComponent
    {
        IManageFeedRepo frepo;
        public PendingFeedsVC(IManageFeedRepo frepo)
        {
            this.frepo = frepo;
        }

        public IViewComponentResult Invoke()
        {
            var res= this.frepo.GetPendingFeeds();
            return View(res);
        }
    }
}
