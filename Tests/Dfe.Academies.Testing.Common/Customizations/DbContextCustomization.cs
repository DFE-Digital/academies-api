using AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Testing.Common.Customizations
{
    //public class DbContextCustomization<TContext> : ICustomization where TContext : DbContext
    //{
    //    //public void Customize(IFixture fixture)
    //    //{
    //    //    fixture.Customize<TContext>(composer => composer.FromFactory(() =>
    //    //    {
    //    //        var options = new DbContextOptionsBuilder<TContext>()
    //    //            .UseInMemoryDatabase(Guid.NewGuid().ToString())
    //    //            .Options;

    //    //        return (TContext)Activator.CreateInstance(typeof(TContext), options);
    //    //    }));
    //    //}
    //}

}
