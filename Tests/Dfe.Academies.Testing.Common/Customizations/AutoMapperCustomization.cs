using AutoFixture;
using AutoMapper;

namespace Dfe.Academies.Testing.Common.Customizations
{
    public class AutoMapperCustomization<TMapperProfile> : ICustomization
        where TMapperProfile : Profile
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<IMapper>(composer => composer.FromFactory(() =>
            {
                var profile = Activator.CreateInstance<TMapperProfile>();
                var config = new MapperConfiguration(cfg => cfg.AddProfile(profile));
                return config.CreateMapper();
            }));
        }
    }
}
