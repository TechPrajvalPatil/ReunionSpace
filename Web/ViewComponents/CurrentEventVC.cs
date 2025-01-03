using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class CurrentEventVC:ViewComponent
    {
        IEventRepo erepo;
        public CurrentEventVC(IEventRepo erepo)
        {
            this.erepo = erepo;
        }


        public IViewComponentResult Invoke()
        {
            var res = this.erepo.CurrentEvents();
            return View(res);
        }
    }
}
