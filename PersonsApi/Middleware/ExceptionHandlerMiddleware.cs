using PersonsApi.ResponseModels;
using System.Net;
using System.Text.Json;

namespace PersonsApi.Middleware;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);

            // Check for 401 or 403 status codes after the request has been processed
            if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                await HandleUnauthorizedResponseAsync(context);
            }
            else if (context.Response.StatusCode == (int)HttpStatusCode.Forbidden)
            {
                await HandleForbiddenResponseAsync(context);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("An exception occurred: {Message}", ex.Message);
            _logger.LogError("Stack Trace: {StackTrace}", ex.StackTrace);

            await HandleExceptionAsync(context, ex);
        }
    }

    // Handle 401 Unauthorized
    private async Task HandleUnauthorizedResponseAsync(HttpContext context)
    {
        _logger.LogWarning("Unauthorized access attempt detected.");
        context.Response.ContentType = "application/json";
        var errorResponse = new ErrorResponse
        {
            StatusCode = context.Response.StatusCode,
            Message = "You are not authorized to access this resource."
        };
        await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }

    // Handle 403 Forbidden
    private async Task HandleForbiddenResponseAsync(HttpContext context)
    {
        _logger.LogWarning("Forbidden access attempt detected.");
        context.Response.ContentType = "application/json";
        var errorResponse = new ErrorResponse
        {
            StatusCode = context.Response.StatusCode,
            Message = "You do not have permission to access this resource."
        };
        await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }

    // Handle general exceptions (500 Internal Server Error)
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        var errorResponse = new ErrorResponse
        {
            StatusCode = context.Response.StatusCode,
            Message = "Internal Server Error: " + exception.Message
        };

        _logger.LogError("Unhandled Exception: {Message}", exception.Message);
        _logger.LogError("Stack Trace: {StackTrace}", exception.StackTrace);

        await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }
}