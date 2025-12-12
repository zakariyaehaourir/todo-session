using Microsoft.AspNetCore.Mvc.Filters;
using State_Managment.Options;
using State_Managment.Services;
using System.Diagnostics;
using System.Text.Json;
namespace State_Managment.Filters
{
    public class LoggerFilter :ActionFilterAttribute
    {

        private readonly IFileService _fileService;
        public LoggerFilter(IFileService fileService)
        {
            _fileService = fileService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string controller = context.RouteData.Values["controller"]?.ToString();
            string action = context.RouteData.Values["action"]?.ToString();
            string userAuth = context.HttpContext.Session.GetString("UserAuth");
            string parameters = "";
            if (context.ActionDescriptor.Parameters.Any())
            {
                foreach (var item in context.ActionArguments)
                {
                    var json = JsonSerializer.Serialize(item.Value);
                    parameters += json;
                }
            }
            else
            {
                parameters = "null";
            }
                _fileService.WriteToFile($"{timestamp} | Controller={controller}, Action={action}, User Connected={userAuth}, Params={parameters}");
                Debug.WriteLine($"{timestamp} | Controller={controller}, Action={action}, User Connected={userAuth ?? null}, Params={parameters}");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            // Code exécuté APRÈS l'action
        }
    }
}
