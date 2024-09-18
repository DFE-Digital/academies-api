using AutoFixture;
using AutoMapper;
using Dfe.Academies.Application.MappingProfiles;
using System.Reflection;

namespace Dfe.Academies.Testing.Common.Customizations
{
    public class AutoMapperCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<IMapper>(composer => composer.FromFactory(() =>
            {
                var profiles = typeof(ConstituencyProfile).Assembly
                    .GetTypes()
                    .Where(t => typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract)
                    .ToList();

                var config = new MapperConfiguration(cfg =>
                {
                    foreach (var profileType in profiles)
                    {
                        var profileInstance = (Profile)Activator.CreateInstance(profileType)!;
                        cfg.AddProfile(profileInstance);
                    }
                });

                return config.CreateMapper();
            }));
        }
    }
}
