using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.Tripster.Data.Utility
{
    public class LoggingMiddleware
    {
        private readonly ILogger<LoggingMiddleware> logger;
        private readonly RequestDelegate next;

        public LoggingMiddleware(ILogger<LoggingMiddleware> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Items["CorrelationId"] = Guid.NewGuid().ToString();
            logger.LogInformation($"About to start {context.Request.Method} {context.Request.Path.ToUriComponent()} request");

            await next(context);

            logger.LogInformation($"Request completed with status code: {context.Response.StatusCode} ");
        }
    }
}
