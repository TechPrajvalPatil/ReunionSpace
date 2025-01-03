using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class MemberLoginVC:ViewComponent
    {
        IMemberRepo mrepo;
        public MemberLoginVC(IMemberRepo mrepo)
        {
            this.mrepo = mrepo;
        }


        public IViewComponentResult Invoke()
        {
            return View(new LoginVM());
        }

    }
}
