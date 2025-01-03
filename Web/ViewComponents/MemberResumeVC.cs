using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class MemberResumeVC:ViewComponent
    {
        IProfileRepo prepo;
        public MemberResumeVC(IProfileRepo prepo)
        {
            this.prepo = prepo;
        }

        public IViewComponentResult Invoke()
        {
            var memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));
            var res = this.prepo.GetMemberResumesByMemberId(memberId);
            return View(res);
        }
    }
}
