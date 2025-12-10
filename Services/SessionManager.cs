
using System.Text.Json;

namespace State_Managment.Services
{
    public class SessionManager : ISessionManager
    {
        IHttpContextAccessor _http;
        public SessionManager(IHttpContextAccessor http)
        {
            _http = http;
        }

        public T GetSession<T>(string key)
        {
            if(IsExist(key))
                return JsonSerializer.Deserialize<T>(_http.HttpContext.Session.GetString(key));
            return default;
        }

        public bool IsExist(string key)
        {

            return _http.HttpContext.Session.GetString(key) != null;
        }

        public void SetSession<T>(string key, T objet)
        {
            _http.HttpContext.Session.SetString(key, JsonSerializer.Serialize<T>(objet));
        }
    }
}
