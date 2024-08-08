using PersonsApi.UseCases;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            var allTypes = typeof(IUseCase<,>).Assembly.GetTypes();

            foreach (var type in allTypes)
            {
                foreach (var @interface in type.GetInterfaces())
                {
                    if (@interface.IsGenericType && @interface.GetGenericTypeDefinition() == typeof(IUseCase<,>))
                    {
                        services.AddScoped(@interface, type);
                    }
                }
            }
            return services;
        }
    }
}
