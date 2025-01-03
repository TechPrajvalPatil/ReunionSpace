using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class NewEventRegVC:ViewComponent
    {
        IEventRegRepo repo;
        public NewEventRegVC(IEventRegRepo repo)
        {
            this.repo = repo;
        }

        public IViewComponentResult Invoke()
        {
            var res = this.repo.NewRegistration();
            return View(res);
        }
    }
}
