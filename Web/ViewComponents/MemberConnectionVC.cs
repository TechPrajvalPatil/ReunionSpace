using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class MemberConnectionVC:ViewComponent
    {
        IMemberStatusRepo srepo;
        public MemberConnectionVC(IMemberStatusRepo srepo)
        {
            this.srepo = srepo;
        }

        public IViewComponentResult Invoke(Int64 memberId)
        {
            var res=this.srepo.GetMemberConnectionsByMemberId(memberId);
            return View(res);
        }
    }
}
