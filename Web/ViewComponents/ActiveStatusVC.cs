using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class ActiveStatusVC:ViewComponent
    {
        IMemberStatusRepo srepo;
        public ActiveStatusVC(IMemberStatusRepo srepo)
        {
            this.srepo = srepo;
        }


        public IViewComponentResult Invoke()
        {
            var res = this.srepo.GetActivatedList();
            return View(res);
        }
    }
}
