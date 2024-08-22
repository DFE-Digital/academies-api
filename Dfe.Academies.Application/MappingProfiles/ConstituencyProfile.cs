using AutoMapper;
using Dfe.Academies.Application.Models;

namespace Dfe.Academies.Application.MappingProfiles
{
    public class ConstituencyProfile : Profile
    {
        public ConstituencyProfile()
        {
            CreateMap<ConstituencyWithMemberContactDetails, MemberOfParliament>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Constituency.MemberID))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Constituency.NameList.Split(",", StringSplitOptions.None)[1].Trim()))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Constituency.NameList.Split(",", StringSplitOptions.None)[0].Trim()))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.MemberContactDetails.Email))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Constituency.NameDisplayAs))
                .ForMember(dest => dest.DisplayNameWithTitle, opt => opt.MapFrom(src => src.Constituency.NameFullTitle))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => new List<string> { "Member of Parliament" }))
                .ForMember(dest => dest.ConstituencyName, opt => opt.MapFrom(src => src.Constituency.ConstituencyName));
        }
    }
}