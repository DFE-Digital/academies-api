using System;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TramsDataApi.Swagger
{
    public class SwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        private const string ApiKeyName = "ApiKey";
        private const string ServiceTitle = "Academies API";
        private const string ServiceDescription = "The Academies API provides users with access to a variety of data " +
                                           "regarding academies and trusts in England.\n\n" +
                                           "The available data includes general data acadamy transfers and " +
                                           "applications to become an academy and is compiled from a variety of internal and " +
                                           "external services.";
        private const string ContactName = "Support";
        private const string ContactEmail = "servicedelivery.rdd@education.gov.uk";

        private const string SecuritySchemeDescription = "A valid ApiKey in the 'ApiKey' header is required to " +
                                                         "access the Academies API.";
        private const string DepreciatedMessage = "- API version has been depreciated.";
        
        public SwaggerOptions(IApiVersionDescriptionProvider provider) => _provider = provider;
        
        public void Configure(string name, SwaggerGenOptions options) => Configure(options);
        
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var desc in _provider.ApiVersionDescriptions)
            {
                var openApiInfo = new OpenApiInfo
                {
                    Title = ServiceTitle,
                    Description = ServiceDescription,
                    Contact = new OpenApiContact
                    {
                        Name = ContactName,
                        Email = ContactEmail 
                    },
                    Version = desc.ApiVersion.ToString()
                };
                if (desc.IsDeprecated) openApiInfo.Description += DepreciatedMessage;
                
                options.SwaggerDoc(desc.GroupName, openApiInfo);
            }
            
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = ApiKeyName,
                Description = SecuritySchemeDescription,
                Type = SecuritySchemeType.ApiKey,
                In = ParameterLocation.Header
            };
            options.AddSecurityDefinition(ApiKeyName, securityScheme);
            options.OperationFilter<AuthenticationHeaderOperationFilter>();
        }
    }
}