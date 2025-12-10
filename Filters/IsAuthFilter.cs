using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace State_Managment.Filters
{
    public class IsAuthFilter : ActionFilterAttribute
    {
        

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var IsConnected = context.HttpContext.Session.GetString("IsAuth");
            if (IsConnected == null)
            {
                context.Result = new RedirectToActionResult("Register", "User", null);
            }
            
        }
    }
}
