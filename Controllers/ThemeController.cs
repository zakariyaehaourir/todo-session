using Microsoft.AspNetCore.Mvc;

namespace State_Managment.Controllers
{
    public class ThemeController : Controller
    {
        public IActionResult SetTheme()
        {
            if (HttpContext.Request.Cookies["bg-color"] == "dark")
            {
                HttpContext.Response.Cookies.Append("bg-color", "white");
            }
            else
            {
                HttpContext.Response.Cookies.Append("bg-color", "dark");
            }

            return RedirectToAction("Index", "Todo", null);
        }
    }
}
