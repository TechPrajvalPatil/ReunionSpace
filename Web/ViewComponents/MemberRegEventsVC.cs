using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class MemberRegEventsVC:ViewComponent
    {
        IMemberStatusRepo srepo;
        IEventRegRepo regrepo;
        public MemberRegEventsVC(IMemberStatusRepo srepo,IEventRegRepo regrepo)
        {
            this.srepo = srepo;
            this.regrepo = regrepo;
        }

        public IViewComponentResult Invoke(Int64 id)
        {
            var res = this.regrepo.MemberEventRegistrations(id);
            return View(res);
        }
    }
}
