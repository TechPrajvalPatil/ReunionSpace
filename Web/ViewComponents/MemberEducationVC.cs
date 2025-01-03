using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class MemberEducationVC:ViewComponent
    {
        IProfileRepo prepo;
        public MemberEducationVC(IProfileRepo prepo)
        {
            this.prepo = prepo;
        }

        public IViewComponentResult Invoke()
        {
            Int64 memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));
            var res = this.prepo.GetMemberEducationByMemberId(memberId);
            return View(res);
        }

    }
}
