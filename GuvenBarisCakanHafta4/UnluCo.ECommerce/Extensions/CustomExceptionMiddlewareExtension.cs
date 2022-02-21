using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using UnluCo.ECommerce.Middlewares;

namespace UnluCo.ECommerce.Extensions
{
    // middleware 'ın app.Use olarak kullanılması için yazılan Extension(App methoduna extend edilmiştir.) 
    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomeExceptionMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
