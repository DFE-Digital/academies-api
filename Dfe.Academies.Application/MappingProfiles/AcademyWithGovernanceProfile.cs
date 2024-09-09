using AutoMapper;
using Dfe.Academies.Application.Common.Models;
using Dfe.Academies.Domain.Establishment;

namespace Dfe.Academies.Application.MappingProfiles
{
    public class AcademyWithGovernanceProfile : Profile
    {
        public AcademyWithGovernanceProfile()
        {
            CreateMap<EducationEstablishmentGovernance, AcademyGovernance>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SK))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Forename1))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => $"{src.Forename1} {src.Surname}"))
                .ForMember(dest => dest.DisplayNameWithTitle, opt => opt.MapFrom(src => $"{src.Title} {src.Forename1} {src.Surname}"))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => new List<string> { src.GovernanceRoleType.Name }))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.Modified));

            CreateMap<Domain.Establishment.Establishment, List<AcademyGovernance>>()
                .ConvertUsing((src, dest, context) => src.EducationEstablishmentGovernances
                    .Select(g => 
                    {
                        var academyGovernance = context.Mapper.Map<AcademyGovernance>(g);
                        academyGovernance.URN = src.URN;
                        academyGovernance.UKPRN = src.UKPRN;
                        return academyGovernance;
                    })
                    .ToList());
        }
    }
  
}
