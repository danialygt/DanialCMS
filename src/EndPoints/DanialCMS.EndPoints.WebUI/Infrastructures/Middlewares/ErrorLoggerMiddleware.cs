using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace DanialCMS.EndPoints.WebUI.Infrastructures.Middlewares
{
     public class ErrorLoggerMiddleware
     {
        private readonly RequestDelegate _next;

        public ErrorLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogger<ErrorLoggerMiddleware> logger)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
                logger.TextLogCritical(ex, "have exception :{0} --- {1} --- {2}", DateTime.Now, GetRequestInfo(httpContext), GetResponseInfo(httpContext));
            }
        }

        private string GetResponseInfo(HttpContext Context)
        {
            return $"Response: {Context.Response.StatusCode} {Context.Response.ContentType} ";
        }

        private string GetRequestInfo(HttpContext context)
        {
            return $"Request:  {context.Request.Method} {context.Request.Scheme} " +
                $"{context.Request.Host} {context.Request.Path} " +
                $"IPAddress: {context.Connection.RemoteIpAddress}";
        }
    }

    
    public static class ErrorLoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorLoggerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorLoggerMiddleware>();
        }
    }
}
