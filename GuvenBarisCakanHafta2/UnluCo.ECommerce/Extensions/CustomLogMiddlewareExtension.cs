using Microsoft.AspNetCore.Builder;
using UnluCo.ECommerce.Middlewares;

namespace UnluCo.ECommerce.Extensions
{
    public static class CustomLogMiddlewareExtension
    {
        // middleware 'ın app.Use olarak kullanılması için yazılan Extension(App methoduna extend edilmiştir.) 
        public static IApplicationBuilder UseCustomLogMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomLogMiddleware>();
        }
    }
}
