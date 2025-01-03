using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class CheckBoxListVC:ViewComponent
    {
        ISkillsRepo srepo;
        public CheckBoxListVC(ISkillsRepo srepo)
        {
            this.srepo = srepo;
        }

        public IViewComponentResult Invoke()
        {
            var res= this.srepo.GetSkills();
            return View(res);
        }
    }
}
