
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Text.Json;
using static System.Net.WebRequestMethods;

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
            if (IsExist(key))
            {
                var data = _http.HttpContext.Session.GetString(key);

                if(typeof(T) == typeof(string))
                {
                    return (T)(object)data; // compliteur refuse cast direct struct -> T
                }
                else
                {
                    return JsonSerializer.Deserialize<T>(data);
                }
            }
                
            return default;
        }

        public bool IsExist(string key)
        {

            return _http.HttpContext.Session.GetString(key) != null;
        }

        public void SetSession<T>(string key, T objet)
        {
            if (objet is string _str)
                _http.HttpContext.Session.SetString(key, _str);
            else
                _http.HttpContext.Session.SetString(key, JsonSerializer.Serialize<T>(objet));
        }

        public bool Clear(string key)
        {
            if (IsExist(key)){
                _http.HttpContext.Session.Remove(key);
                return true;
            }

               
            return false;
        }
    }
}
