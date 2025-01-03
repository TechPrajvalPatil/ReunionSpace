using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class AcceptEventRegVC:ViewComponent
    {
        IEventRegRepo repo;
        public AcceptEventRegVC(IEventRegRepo repo)
        {
            this.repo = repo;
        }

        public IViewComponentResult Invoke()
        {
            var res = this.repo.AcceptedEventRegistration();
            return View(res);
        }
    }
}
