namespace State_Managment.Services
{
    public interface ISessionManager
    {
        public T GetSession<T>(string key);
        public void SetSession<T>(string key ,T objet); //objet soit list soi un autre objet
        public bool IsExist(string key);
        public bool Clear(string key);
    }
}
