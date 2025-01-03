using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class DeActiveStatusVC:ViewComponent
    {
        IMemberStatusRepo srepo;
        public DeActiveStatusVC(IMemberStatusRepo srepo)
        {
            this.srepo = srepo;
        }

        public IViewComponentResult Invoke()
        {
            var res=this.srepo.GetDeActivatedList();
            return View(res);
        }
    }
}
