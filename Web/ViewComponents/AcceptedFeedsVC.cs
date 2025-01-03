using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class AcceptedFeedsVC:ViewComponent
    {

        IManageFeedRepo frepo;
        public AcceptedFeedsVC(IManageFeedRepo frepo)
        {
            this.frepo = frepo;
        }

        public IViewComponentResult Invoke()
        {
            var res = this.frepo.GetAcceptedFeeds();
            return View(res);
        }
    }
}
