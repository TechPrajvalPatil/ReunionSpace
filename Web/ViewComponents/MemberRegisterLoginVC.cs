using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class MemberRegisterLoginVC:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
