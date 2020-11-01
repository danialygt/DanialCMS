using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using DanialCMS.Core.Domain.Analysis.Commands;
using DanialCMS.Core.Domain.Analysis.Entities;
using DanialCMS.Core.Domain.Analysis.Repositories;
using DanialCMS.Framework.Commands;
using DanialCMS.Framework.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace DanialCMS.EndPoints.WebUI.Infrastructures.Middlewares
{
    public class AnalysisMiddleware
    {
        private readonly RequestDelegate _next;

        public AnalysisMiddleware(RequestDelegate next)
        {
            _next = next;
        }        

        public async Task Invoke(HttpContext httpContext, 
            CommandDispatcher commandDispatcher,
            ILogger<AnalysisMiddleware> logger)
        {
            var dto = new AddRecordCommand();
          
            dto.OsName = RuntimeInformation.OSDescription;
            dto.OSArchitecture = RuntimeInformation.OSArchitecture.ToString();

            dto.BrowserName = httpContext.Request?.Headers["User-Agent"].ToString();
            dto.Referer = httpContext.Request?.Headers["Referer"].ToString();
            dto.Scheme = httpContext.Request?.Headers["Scheme"].ToString();
            
            dto.Protocol = httpContext.Request?.Protocol;
            dto.IsHttps = httpContext.Request?.IsHttps;
            dto.Path = httpContext.Request?.Path.Value;
            dto.Host = httpContext.Request?.Host.Host;
            dto.Port = httpContext.Request?.Host.Port;

            dto.HttpMethod = httpContext.Request?.Method?.ToString();
            dto.RemoteIpAddress = httpContext.Request?.HttpContext.Connection.RemoteIpAddress?.ToString();
            dto.RemotePort = httpContext.Request?.HttpContext.Connection.RemotePort;
            dto.HasCockies = httpContext.Request?.Cookies.Any();
           
            await _next(httpContext);

            dto.ContentType = httpContext.Response?.ContentType?.ToString();
            dto.ContentLength = httpContext.Response?.ContentLength;
            dto.SatusCode = httpContext.Response?.StatusCode;

            dto.UserName = httpContext.User?.Identity?.Name;

            var result = commandDispatcher.Dispatch(dto);
            if (!result.IsSuccess)
            {
                logger.TextLogError("analysis dosent add to db");
                foreach (var err in result.Errors)
                {
                    logger.TextLogError("-- {0}", err);
                }
            }
        }
    }

    public static class AnalysisMiddlewareExtensions
    {
        public static IApplicationBuilder UseAnalysisMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AnalysisMiddleware>();
        }
    }
}
