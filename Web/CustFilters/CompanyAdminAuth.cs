using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.CustFilters
{
    public class CompanyAdminAuth : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(context.HttpContext.Session.GetString("CompanyAdminId")==null)
            {
                context.Result = new RedirectToActionResult("Login", "ManageCompanyAdmin", new { area = "" });
            }
        }
    }
}
