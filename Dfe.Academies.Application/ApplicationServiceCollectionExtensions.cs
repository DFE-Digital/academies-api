using Dfe.Academies.Application.Common.Behaviours;
using Dfe.Academies.Application.EducationalPerformance;
using Dfe.Academies.Application.Establishment;
using Dfe.Academies.Application.Trust;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using FluentValidation;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationDependencyGroup(
             this IServiceCollection services, IConfiguration config)
        {
            //Queries
            services.AddScoped<ITrustQueries, TrustQueries>();
            services.AddScoped<IEstablishmentQueries, EstablishmentQueries>();
            services.AddScoped<IEducationalPerformanceQueries, EducationalPerformanceQueries>();
            services.AddScoped<IEducationalPerformanceQueries, EducationalPerformanceQueries>();

            return services;
        }

        public static IServiceCollection AddPersonsApiApplicationDependencyGroup(
            this IServiceCollection services, IConfiguration config)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            });

            return services;
        }
    }
}