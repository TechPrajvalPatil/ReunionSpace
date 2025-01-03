using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class CreateFeedVC:ViewComponent
    {
        IFeedRepo frepo;
        public CreateFeedVC(IFeedRepo frepo)
        {
            this.frepo = frepo;
        }

        public IViewComponentResult Invoke()
        {
            
            return View();
        }
    }
}
