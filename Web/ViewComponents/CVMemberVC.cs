using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class CVMemberVC:ViewComponent
    {
        IProfileRepo prepo;
        public CVMemberVC(IProfileRepo prepo)
        {
            this.prepo = prepo;
        }

        public IViewComponentResult Invoke(Int64 memberId)
        {
            var res = this.prepo.GetMemberResumesByMemberId(memberId);
            return View(res);
        }
    }
}
