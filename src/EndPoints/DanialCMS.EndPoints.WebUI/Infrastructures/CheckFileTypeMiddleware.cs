using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace DanialCMS.EndPoints.WebUI.Infrastructures
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CheckFileTypeMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckFileTypeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if(httpContext.Request.Method.ToLower() == "post")
            {
                var type = httpContext.Request.Form.Files.First().ContentType;
            }

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CheckFileTypeMiddlewareExtensions
    {
        public static IApplicationBuilder UseCheckFileTypeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckFileTypeMiddleware>();
        }
    }
}
