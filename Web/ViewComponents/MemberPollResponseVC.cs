using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class MemberPollResponseVC:ViewComponent
    {
        IMemberStatusRepo srepo;
        public MemberPollResponseVC(IMemberStatusRepo srepo)
        {
            this.srepo = srepo;
        }

        public IViewComponentResult Invoke(Int64 memberId)
        {
            var res = this.srepo.GetPollResponsesByMemberId(memberId);
            return View(res);
        }
    }
}
