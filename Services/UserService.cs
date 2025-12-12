using Microsoft.AspNetCore.Identity;
using State_Managment.ViewModels;

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
        public void SetUserSession(UserVM request)
        {
           
                //Creation d'user dans la session à l'aide de ession manager
              _sessionManager.SetSession<string>("UserAuth", request.Login);

        }

        public bool Logout()
        {
            return _sessionManager.Clear("UserAuth");
        }
           

            
    }
}
