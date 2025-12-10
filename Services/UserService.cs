namespace State_Managment.Services
{
    public class UserService :IUserService
    {
        public bool IsAuthenticated(string login , string password)
        {
            return login.Equals(password);
        }
    }
}
