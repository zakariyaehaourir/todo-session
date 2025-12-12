using State_Managment.ViewModels;

namespace State_Managment.Services
{
    public interface IUserService
    {
        public bool IsAuthenticated(UserVM request);
        public Task SetUserSession(UserVM request , HttpContext http);
        public bool Logout();
    }
}
