using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Enviro365Assessment_Grad_DOTNET_version;

public class ErrorHandlerMiddleware
{
    private readonly ILogger _logger;
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }


    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            ProblemDetails errorResponse = new()
            {
                Title = ex.Message,
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = context.Request.Path.Value
            };

            _logger.LogCritical(ex, "Exception has been thrown, from WasteError: ");
            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    }
}
