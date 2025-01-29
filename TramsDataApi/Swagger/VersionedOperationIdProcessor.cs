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
            var version = "V1"; // Default version
            var apiVersionAttr = context.ControllerType
                ?.GetCustomAttributes(typeof(ApiVersionAttribute), true)
                .FirstOrDefault() as ApiVersionAttribute;

            if (apiVersionAttr != null && apiVersionAttr.Versions.Count > 0)
            {
                version = $"V{apiVersionAttr.Versions[0].MajorVersion}";
            }

            var actionName = context.MethodInfo.Name;

            context.OperationDescription.Operation.OperationId = $"{version}{actionName}";

            return true;
        }
    }
}
