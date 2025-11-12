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
            services.AddScoped<Dfe.Academies.Application.Establishment.V5.IEstablishmentQueries,  Dfe.Academies.Application.Establishment.V5.EstablishmentQueries>();
            services.AddScoped<IEducationalPerformanceQueries, EducationalPerformanceQueries>();
            services.AddScoped<IEducationalPerformanceQueries, EducationalPerformanceQueries>();

            return services;
        }
    }
}