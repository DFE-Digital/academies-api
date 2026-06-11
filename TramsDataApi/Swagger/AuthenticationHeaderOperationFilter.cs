using System.Collections.Generic;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TramsDataApi.Swagger
{
    public class AuthenticationHeaderOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Security ??= new List<OpenApiSecurityRequirement>();
            
            var securitySchemeReference = new OpenApiSecuritySchemeReference("ApiKey");

            operation.Security.Add(new OpenApiSecurityRequirement
            {        
                { securitySchemeReference, new List<string>() }
            });
        }
    }
}