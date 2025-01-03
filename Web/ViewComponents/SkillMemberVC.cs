using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class SkillMemberVC:ViewComponent
    {
        IProfileRepo prepo;
        public SkillMemberVC(IProfileRepo prepo)
        {
            this.prepo = prepo;
        }

        public IViewComponentResult Invoke(Int64 memberId)
        {
            var res = this.prepo.GetMemberSkills(memberId);
            return View(res);
        }
    }
}
