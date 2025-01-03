using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.CustFilters
{
    public class MemberAuth : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(context.HttpContext.Session.GetString("MemberId")== null)
            {
                context.Result = new RedirectToActionResult("Register", "ManageMember", new {area=""});
            }
        }
    }
}
