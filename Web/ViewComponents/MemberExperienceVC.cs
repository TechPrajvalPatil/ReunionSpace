using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class MemberExperienceVC:ViewComponent
    {
        IProfileRepo prepo;
        public MemberExperienceVC(IProfileRepo prepo)
        {
            this.prepo = prepo;
        }

        public IViewComponentResult Invoke()
        {
            Int64 memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));
            var res = this.prepo.GetMemberExperienceByMemberId(memberId);
            return View(res);
            
        }
    }
}
