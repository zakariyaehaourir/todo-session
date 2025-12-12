using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using State_Managment.ViewModels;
using System.Security.Claims;

namespace State_Managment.Services
{
    public class UserService :IUserService
    {
        private readonly ISessionManager _sessionManager;
        public UserService(ISessionManager sessionManager)
        {
            this._sessionManager=sessionManager;
        }
        public bool IsAuthenticated(UserVM request)
        {
            return request.Login.Equals(request.Password);
        }
        //Pratique auth schema :
        /**
         1)Creation de claims qui identife chaque user
            identity represente l'ensemble des claims , une claim c'est une descri de l'identity
        2)Creation de claims Identity qui est un ensemble des claims
            il est ataché a une schema définit pour connaitre comment gérer
        3)Creation de claims principale 
        4) signé le cookie et envoi au client
        5) à la prochaine requette le middl UseAuth va intercepter chaque requette :
            - lire la cookie si exist
            - Déserialiser les claims de ce user
            - Populer le User par ces claims
            - Et voila on a un User avefc ces claims on peut traviller avec User.
            - Si la cookie inexistante ce user est pas authentifier
         */
        public async Task SetUserSession(UserVM request , HttpContext http)
        {
           
            ClaimsIdentity identity = new ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.Role , "Admin"),  //Just une simulation pour tester 
                    new Claim(ClaimTypes.Name , request.Login)
                } ,

                "DefaultAuth"
                );
            ClaimsPrincipal principal = new(identity);
            await http.SignInAsync("DefaultAuth", principal);
        }

        public bool Logout()
        {
            return _sessionManager.Clear("UserAuth");
        }
           

            
    }
}
