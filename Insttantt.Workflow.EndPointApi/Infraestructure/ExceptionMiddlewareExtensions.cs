using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace Insttantt.Workflow.EndPointApi.Infraestructure
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError($"Ocurrio un error: {contextFeature.Error}");

                        var response = new ProblemDetails()
                        {
                            Title = "Error Workflow Api Insttantt-ISO RFC 7807",
                            Status = context.Response.StatusCode,
                            Detail = contextFeature.Error.Message,
                            Instance = contextFeature.Path
                        };
                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    }
                });
            });
        }

    }
}
