using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Application.Queries.Establishment;
using Dfe.Academies.Application.Queries.Trust;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Trust;
using Dfe.Academies.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dfe.Academies.Application
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

            //Repos
            services.AddScoped<ITrustRepository, TrustRepository>();
            services.AddScoped<IEstablishmentRepository, EstablishmentRepository>();

            //Db
            services.AddDbContext<MstrContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}