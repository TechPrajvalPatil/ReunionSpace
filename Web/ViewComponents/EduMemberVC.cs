using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class EduMemberVC:ViewComponent
    {
        IProfileRepo prepo;
        public EduMemberVC(IProfileRepo prepo)
        {
            this.prepo = prepo;
        }

        public IViewComponentResult Invoke(Int64 memberId)
        {
            var res = this.prepo.GetMemberEducationByMemberId(memberId);
            return View(res);
        }
    }
}
