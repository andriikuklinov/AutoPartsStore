using Microsoft.AspNetCore.Builder;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class LogExtension
    {
        public static IApplicationBuilder UseLogger(this IApplicationBuilder app, string assembly)
        {
            app.UseSerilogRequestLogging(options =>
            {
                options.MessageTemplate = "Assembly: {Assembly}; Host: {RequestHost}; Request method: {RequestMethod}; Request path: {RequestPath}; Status code: {StatusCode}; Time: {Elapsed}";

                options.GetLevel = (context, elapsed, exception) => LogEventLevel.Error;

                options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
                {
                    diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
                    diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
                    diagnosticContext.Set("Assembly", assembly);
                };
            });
            return app;
        }
    }
}
