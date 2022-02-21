using System;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace UnluCo.ECommerce.Middlewares
{
    //Request geldikten Response oluşuna kadar geçen sürede oluşacak bütün hataları yakalayarak belirli bir hata
    //formatın da geri dönülmesi için bir customException Middleware yazılmıştır.
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {

                int statusCode;
                switch(ex)
                {
                    //Yetkisiz kullanıcı hatası olduğunun da 401 dönmek için.
                    case AuthenticationException e:
                        statusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                    default:
                        statusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                }

                await HandleExceptionAsync(httpContext,statusCode, ex);
            }
        }
        //Hata yakalandığın da hatanın geri nasıl dönmesi gerektiğini yazdığımız method.
        private async Task HandleExceptionAsync(HttpContext context,int statusCode, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var result = JsonConvert.SerializeObject(new { context.Response.StatusCode,error = exception.Message});
            await context.Response.WriteAsync(result);
        }
    }

}
