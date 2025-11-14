using Dfe.Academies.Domain.Interfaces.Repositories;
using Dfe.Academies.Infrastructure;
using Dfe.Academies.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureDependencyGroup(
             this IServiceCollection services, IConfiguration config)
        {
            //Repos
            services.AddScoped<ITrustRepository, TrustRepository>();
            services.AddScoped<IEstablishmentRepository, EstablishmentRepository>();
            services.AddSingleton<ICensusDataRepository, CensusDataRepository>();
            services.AddScoped<IEducationalPerformanceRepository, EducationalPerformanceRepository>();
            services.AddScoped<ISignificantChangeRepositiory, SignificantChangeRepositiory>();

            //Db
            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<MstrContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDbContext<EdperfContext>(options =>
                options.UseSqlServer(connectionString));
            
            services.AddDbContext<MisMstrContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDbContext<SigChgMstrContext>(options =>
                options.UseSqlServer(connectionString));

            AddInfrastructureHealthChecks(services);

            return services;
        }

        public static void AddInfrastructureHealthChecks(this IServiceCollection services) {
            services.AddHealthChecks()
                .AddDbContextCheck<MstrContext>("Academies Database");
        }
    }
}
