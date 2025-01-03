using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;

namespace Web.ViewComponents
{
    public class ExpiredEventVC:ViewComponent
    {
        IEventRepo erpo;
        public ExpiredEventVC(IEventRepo erpo)
        {
            this.erpo = erpo;
        }


        public IViewComponentResult Invoke()
        {
            var res = this.erpo.ExpiredEvents();
            return View(res);
        }
    }
}
