using Microsoft.AspNetCore.Mvc;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;
using System.Linq;

namespace TramsDataApi.Swagger
{
    public class VersionedOperationIdProcessor : IOperationProcessor
    {
        public bool Process(OperationProcessorContext context)
        {
            var version = "V1"; // Default

            if (context.ControllerType?
                    .GetCustomAttributes(typeof(ApiVersionAttribute), true)
                    .FirstOrDefault() is ApiVersionAttribute apiVersionAttr && apiVersionAttr.Versions.Count > 0)
            {
                version = $"V{apiVersionAttr.Versions[0].MajorVersion}";
            }

            var controllerName = context.ControllerType?.Name.Replace("Controller", "") ?? "Unknown";

            var actionName = context.MethodInfo.Name;
            context.OperationDescription.Operation.OperationId = actionName;

            var apiVersionParam = context.OperationDescription.Operation.Parameters
                .FirstOrDefault(p => p.Name == "api-version");

            if (apiVersionParam != null)
            {
                context.OperationDescription.Operation.Parameters.Remove(apiVersionParam);
            }

            var clientTag = $"{controllerName}{version}";

            if (!context.OperationDescription.Operation.Tags.Any(t => t == clientTag))
            {
                context.OperationDescription.Operation.Tags.Insert(0, clientTag);
            }

            return true; 
        }
    }
}
