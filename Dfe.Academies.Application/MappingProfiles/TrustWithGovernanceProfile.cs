using AutoMapper;
using Dfe.Academies.Application.Common.Models;

namespace Dfe.Academies.Application.MappingProfiles
{
    public class TrustWithGovernanceProfile : Profile
    {
        public TrustWithGovernanceProfile()
        {
            CreateMap<TrustGovernanceQueryModel, TrustGovernance>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => (int)src.TrustGovernance.SK))
                .ForMember(dest => dest.UKPRN, opt => opt.MapFrom(src => src.Trust.UKPRN))
                .ForMember(dest => dest.TRN, opt => opt.MapFrom(src => src.Trust.GroupID))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.TrustGovernance.Forename1))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.TrustGovernance.Surname))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.TrustGovernance.Email))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => $"{src.TrustGovernance.Forename1} {src.TrustGovernance.Surname}"))
                .ForMember(dest => dest.DisplayNameWithTitle, opt => opt.MapFrom(src => $"{src.TrustGovernance.Title} {src.TrustGovernance.Forename1} {src.TrustGovernance.Surname}"))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => new List<string?> { src.GovernanceRoleType.Name }))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.TrustGovernance.Modified));
        }
    }
}