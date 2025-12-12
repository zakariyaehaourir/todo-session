using State_Managment.ViewModels;

namespace State_Managment.Services
{
    public interface IUserService
    {
        public bool IsAuthenticated(UserVM request);
        public void SetUserSession(UserVM request);
        public bool Logout();
    }
}
