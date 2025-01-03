using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class MemberSkillVC:ViewComponent
    {
        IProfileRepo prepo;
        public MemberSkillVC(IProfileRepo prepo)
        {
            this.prepo = prepo;
        }

        public IViewComponentResult Invoke()
        {
            Int64 memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));
            var memberSkills = this.prepo.GetMemberSkills(memberId);
            return View(memberSkills);
        }
    }
}
