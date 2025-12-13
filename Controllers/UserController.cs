using Microsoft.AspNetCore.Mvc;
using State_Managment.Enums;
using State_Managment.Filters;
using State_Managment.Services;
using State_Managment.ViewModels;
using System.Text.Json;

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
            if (_userService.IsAuthenticated(Request))
            {
                _userService.SetUserSession(Request);
                TempData["FlashMessage"] = JsonSerializer.Serialize<FlashMessage>(new FlashMessage { Message = "Vous étes connecter , bienvenu "+ Request.Login, Type = FlashMessageTypes.Success });
                //redirection
                return RedirectToAction("Index", "Todo"); //Action , Controller
               
            }
            

            //erreur informations non correct !
            ViewBag.Error = "Identifiants incorrects";
            return View();
        }
        [HttpGet("/Logout")]
        public IActionResult Logout()
        {
            if (_userService.Logout())
            {
                TempData["FlashMessage"] = JsonSerializer.Serialize<FlashMessage>(new FlashMessage { Message = "Vous étes deconecter avec succés", Type = FlashMessageTypes.Success });
                RedirectToAction(nameof(Register));
            }
            return RedirectToAction(nameof(Logout));

        }
    }
}
