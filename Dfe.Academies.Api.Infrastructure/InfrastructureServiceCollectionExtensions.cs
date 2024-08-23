using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Application.Common.Interfaces;
using Dfe.Academies.Infrastructure;
using Dfe.Academies.Infrastructure.Caching;
using Dfe.Academies.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<IConstituencyRepository, ConstituencyRepository>();
            services.AddTransient(typeof(IMopRepository<>), typeof(MopRepository<>));
            services.AddTransient(typeof(IMstrRepository<>), typeof(MstrRepository<>));

            //Cache service
            services.Configure<CacheSettings>(config.GetSection("CacheSettings"));
            services.AddSingleton<ICacheService, MemoryCacheService>();

            //Db
            services.AddDbContext<MstrContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddDbContext<EdperfContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddDbContext<MopContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}