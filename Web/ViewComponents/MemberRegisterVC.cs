using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.ViewComponents
{
    public class MemberRegisterVC:ViewComponent
    {
        IMemberRepo mrepo;
       ICountryRepo crepo;
        public MemberRegisterVC(IMemberRepo mrepo, ICountryRepo crepo)
        {
            this.mrepo = mrepo;
            this.crepo= crepo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.countries = new SelectList(this.crepo.GetAll(), "CountryId", "CountryName");
            return View(new MemberRegisterVM());
        }

        
    }
}
