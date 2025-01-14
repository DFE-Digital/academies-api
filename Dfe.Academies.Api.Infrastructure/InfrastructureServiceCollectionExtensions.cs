﻿using Dfe.Academies.Application.Common.Interfaces;
using Dfe.Academies.Domain.Constituencies;
using Dfe.Academies.Infrastructure;
using Dfe.Academies.Infrastructure.Repositories;
using Dfe.Academies.Infrastructure.Security.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Dfe.Academies.Domain.Interfaces.Repositories;
using Dfe.Academies.Infrastructure.QueryServices;
using Dfe.Academies.Domain.ValueObjects;

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

            //Db
            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<MstrContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDbContext<EdperfContext>(options =>
                options.UseSqlServer(connectionString));
            
            services.AddDbContext<MisMstrContext>(options =>
                options.UseSqlServer(connectionString));

            AddInfrastructureHealthChecks(services);

            return services;
        }

        public static IServiceCollection AddPersonsApiInfrastructureDependencyGroup(
            this IServiceCollection services, IConfiguration config)
        {
            //Repos
            services.AddScoped<ITrustRepository, TrustRepository>();
            services.AddScoped<IEstablishmentRepository, EstablishmentRepository>();
            services.AddScoped<IConstituencyRepository, ConstituencyRepository>();

            // Query Services
            services.AddScoped<IEstablishmentQueryService, EstablishmentQueryService>();
            services.AddScoped<ITrustQueryService, TrustQueryService>();

            //Cache service
            services.AddServiceCaching(config);

            //Db
            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<MstrContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDbContext<MopContext>(options =>
                options.UseSqlServer(connectionString));
            
            services.AddDbContext<MisMstrContext>(options =>
                options.UseSqlServer(connectionString));

            AddInfrastructureHealthChecks(services);

            // Authentication
            services.AddCustomAuthorization(config);

            return services;
        }

        public static void AddInfrastructureHealthChecks(this IServiceCollection services) {
            services.AddHealthChecks()
                .AddDbContextCheck<MstrContext>("Academies Database");
        }
    }
}
