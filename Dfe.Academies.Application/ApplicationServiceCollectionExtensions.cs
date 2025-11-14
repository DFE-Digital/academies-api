using Dfe.Academies.Application.EducationalPerformance;
using Dfe.Academies.Application.Establishment;
using Dfe.Academies.Application.SignificantChange;
using Dfe.Academies.Application.Trust;
using Microsoft.Extensions.Configuration; 

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
            services.AddScoped<Dfe.Academies.Application.Establishment.V5.IEstablishmentQueries,  Dfe.Academies.Application.Establishment.V5.EstablishmentQueries>();
            services.AddScoped<IEducationalPerformanceQueries, EducationalPerformanceQueries>();
            services.AddScoped<IEducationalPerformanceQueries, EducationalPerformanceQueries>();
            services.AddScoped<ISignificantChangeQueries, SignificantChangeQueries>();

            return services;
        }
    }
}