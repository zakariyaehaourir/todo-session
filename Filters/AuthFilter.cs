using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace State_Managment.Filters
{
    public class AuthFilter : ActionFilterAttribute
    {
        

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var IsConnected = context.HttpContext.Session.GetString("UserAuth");
            if (IsConnected == null)
            {
                context.Result = new RedirectToActionResult("Register", "User", null);
            }
            
        }
    }
}
