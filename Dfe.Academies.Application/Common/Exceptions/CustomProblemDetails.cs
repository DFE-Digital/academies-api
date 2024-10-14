using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Dfe.Academies.Application.Common.Exceptions
{
    public class CustomProblemDetails : ProblemDetails
    {
        public CustomProblemDetails(HttpStatusCode statusCode, string? detail = null)
        {
            Status = (int)statusCode;
            Detail = detail;

            Title = statusCode switch
            {
                HttpStatusCode.NotFound => "Not Found",
                HttpStatusCode.Unauthorized => "Unauthorized",
                HttpStatusCode.Forbidden => "Forbidden",
                HttpStatusCode.BadRequest => "Bad Request",
                HttpStatusCode.InternalServerError => "Internal Server Error",
                _ => "An error occurred"
            };

            Type = statusCode switch
            {
                HttpStatusCode.NotFound => "https://tools.ietf.org/html/rfc9110#section-15.5.5",
                HttpStatusCode.Unauthorized => "https://tools.ietf.org/html/rfc7235#section-3.1",
                HttpStatusCode.Forbidden => "https://tools.ietf.org/html/rfc7231#section-6.5.3",
                HttpStatusCode.BadRequest => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                HttpStatusCode.InternalServerError => "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                _ => "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            };
        }
    }
}
