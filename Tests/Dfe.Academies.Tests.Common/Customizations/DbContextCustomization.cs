﻿using AutoFixture;
using Dfe.Academies.Tests.Common.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dfe.Academies.Tests.Common.Customizations
{
    public class DbContextCustomization<TContext> : ICustomization where TContext : DbContext
    {
        public void Customize(IFixture fixture)
        {
            fixture.Register<DbSet<object>>(() => null!);

            fixture.Customize<TContext>(composer => composer.FromFactory(() =>
            {
                var services = new ServiceCollection();
                var dbContext = DbContextHelper<TContext>.CreateDbContext(services);
                fixture.Inject(dbContext);
                return dbContext;
            }).OmitAutoProperties());
        }
    }
}