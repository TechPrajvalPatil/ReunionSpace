using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class ExpMemberVC:ViewComponent
    {
        IProfileRepo prepo;
        public ExpMemberVC(IProfileRepo prepo)
        {
            this.prepo = prepo;
        }

        public IViewComponentResult Invoke(Int64 memberId)
        {
            var res = this.prepo.GetMemberExperienceByMemberId(memberId);
            return View(res);

        }
    }
}
