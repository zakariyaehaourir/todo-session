namespace State_Managment.Services
{
    public interface IUserService
    {
        public bool IsAuthenticated(string login, string password);
    }
}
