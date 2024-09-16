using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonsApi.ResponseModels;
using System.Net;
using System.Text.Json;
using ValidationException = Dfe.Academies.Application.Common.Exceptions.ValidationException;

namespace PersonsApi.Middleware;

public class ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);

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
        catch (ValidationException ex)
        {
            logger.LogError($"Validation error: {ex.Message}");
            await HandleValidationException(context, ex);
        }
        catch (Exception ex)
        {
            logger.LogError("An exception occurred: {Message}", ex.Message);
            logger.LogError("Stack Trace: {StackTrace}", ex.StackTrace);

            await HandleExceptionAsync(context, ex);
        }
    }

    // Handle validation exceptions
    private async Task HandleValidationException(HttpContext httpContext, Exception ex)
    {
        var exception = (ValidationException)ex;

        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

        await httpContext.Response.WriteAsJsonAsync(new ValidationProblemDetails(exception.Errors)
        {
            Status = StatusCodes.Status400BadRequest,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
        });
    }

    // Handle 401 Unauthorized
    private async Task HandleUnauthorizedResponseAsync(HttpContext context)
    {
        logger.LogWarning("Unauthorized access attempt detected.");
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
        logger.LogWarning("Forbidden access attempt detected.");
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

        logger.LogError("Unhandled Exception: {Message}", exception.Message);
        logger.LogError("Stack Trace: {StackTrace}", exception.StackTrace);

        await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }
}