using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Application.EducationalPerformance;
using Dfe.Academies.Application.Establishment;
using Dfe.Academies.Application.Trust;
using Dfe.Academies.Domain.Census;
using Dfe.Academies.Domain.EducationalPerformance;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Trust;
using Dfe.Academies.Infrastructure;
using Dfe.Academies.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationServiceCollectionExtensions
    {
        //public static IServiceCollection AddConfig(
        //     this IServiceCollection services, IConfiguration config)
        //{
        //    services.Configure<PositionOptions>(
        //        config.GetSection(PositionOptions.Position));
        //    services.Configure<ColorOptions>(
        //        config.GetSection(ColorOptions.Color));

        //    return services;
        //}

        public static IServiceCollection AddApplicationDependencyGroup(
             this IServiceCollection services, IConfiguration config)
        {
            //Queries
            services.AddScoped<ITrustQueries, TrustQueries>();
            services.AddScoped<IEstablishmentQueries, EstablishmentQueries>();
            services.AddScoped<IEducationalPerformanceQueries, EducationalPerformanceQueries>();

            //Repos
            services.AddScoped<ITrustRepository, TrustRepository>();
            services.AddScoped<IEstablishmentRepository, EstablishmentRepository>();
            services.AddSingleton<ICensusDataRepository, CensusDataRepository>();
            services.AddScoped<IEducationalPerformanceRepository, EducationalPerformanceRepository>();

            //Db
            services.AddDbContext<MstrContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddDbContext<EdperfContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}