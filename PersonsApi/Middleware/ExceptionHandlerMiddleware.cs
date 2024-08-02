using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PersonsApi.ResponseModels;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext, ILogger<ExceptionHandlerMiddleware> logger)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            logger.LogError($"Something went wrong: {ex}");
            await HandleExceptionAsync(httpContext, ex, logger);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger<ExceptionHandlerMiddleware> logger)
    {
        
        logger.LogError(exception.Message);
        logger.LogError(exception.StackTrace);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
        await context.Response.WriteAsync(new ErrorResponse()
        {
            StatusCode = context.Response.StatusCode,
            Message = "Internal Server Error: " + exception.Message
        }.ToString());
    }
}