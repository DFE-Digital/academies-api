﻿using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Application.Queries.Trust;
using Dfe.Academies.Domain.Trust;
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

            //Repos
            services.AddScoped<ITrustRepository, TrustRepository>();

            //Db
            services.AddDbContext<MstrContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}