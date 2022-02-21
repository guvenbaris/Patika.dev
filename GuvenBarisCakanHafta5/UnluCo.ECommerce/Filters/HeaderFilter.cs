using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UnluCo.ECommerce.Filters
{
    public class HeaderFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

            string date = DateTimeOffset.UtcNow.ToString();
            context.HttpContext.Response.Headers.Add("Response", date);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            string date = DateTimeOffset.UtcNow.ToString();
            context.HttpContext.Response.Headers.Add("Request", date);

        }
    }
}
