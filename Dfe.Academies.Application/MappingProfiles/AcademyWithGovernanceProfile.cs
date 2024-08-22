using AutoMapper;
using Dfe.Academies.Application.Models;

namespace Dfe.Academies.Application.MappingProfiles
{
    public class AcademyWithGovernanceProfile : Profile
    {
        public AcademyWithGovernanceProfile()
        {
            CreateMap<AcademyWithGovernanceDetails, AcademyGovernance>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EducationEstablishmentGovernance.SK))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.EducationEstablishmentGovernance.Forename1))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.EducationEstablishmentGovernance.Surname))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EducationEstablishmentGovernance.Email))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => $"{src.EducationEstablishmentGovernance.Forename1} {src.EducationEstablishmentGovernance.Surname}"))
                .ForMember(dest => dest.DisplayNameWithTitle, opt => opt.MapFrom(src => $"{src.EducationEstablishmentGovernance.Title} {src.EducationEstablishmentGovernance.Forename1} {src.EducationEstablishmentGovernance.Surname}"))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => new List<string> { src.GovernanceRoleType.Name }))
                .ForMember(dest => dest.DateOfAppointment, opt => opt.MapFrom(src => src.EducationEstablishmentGovernance.DateOfAppointment))
                .ForMember(dest => dest.DateTermOfOfficeEndsEnded, opt => opt.MapFrom(src => src.EducationEstablishmentGovernance.DateTermOfOfficeEndsEnded));

        }
    }
}
