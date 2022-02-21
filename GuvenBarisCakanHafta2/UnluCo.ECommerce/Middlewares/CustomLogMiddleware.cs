using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UnluCo.ECommerce.Services;

namespace UnluCo.ECommerce.Middlewares
{
    //Requesti ve Response u log service ile Console a Log layabilmek için Custom Log Middleware yazılmıştır. 
    public class CustomLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;

        public CustomLogMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
        {
            //Log Mesajları ayarlandı.
            string message = $"[Request]  HTTP - {context.Request.Method} - {context.Request.Path}";
            _loggerService.Log(message);
            await _next(context);

            message =
                $"[Response] HTTP - {context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode}";
            _loggerService.Log(message);
        }
    }

}
