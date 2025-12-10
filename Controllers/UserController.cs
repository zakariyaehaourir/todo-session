using Microsoft.AspNetCore.Mvc;
using State_Managment.Services;
using State_Managment.ViewModels;
using System.Diagnostics;

namespace State_Managment.Controllers
{
    public class UserController : Controller
    {
        IUserService _userService;
        public UserController(IUserService userS) {
            this._userService = userS;
        }
        [Route("/Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("/Register")]
        public IActionResult Register(UserVM Request)
        {
           
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Register");
            }
            //Verification simple login == password OK
            if (_userService.IsAuthenticated(Request.Login , Request.Password))
            {
                //1)creation du session
                HttpContext.Session.SetString("IsAuth", Request.Login);
                //2)redirection
                return RedirectToAction("Index", "Home"); //Action , Controller
               

            }
            //erreur informations non correct !
            ViewBag.Error = "Identifiants incorrects";
            return View();
        }
    }
}
