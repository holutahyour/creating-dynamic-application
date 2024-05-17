using Application.Core.Domain;
using AutoMapper;
using WebApi.DTO.Request;

namespace WebApi.Helper;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<CandidateInformation, CandidateInformationDTO>().ReverseMap();
        CreateMap<ProgramApplication, ProgramApplicationDTO>().ReverseMap();
        CreateMap<PersonalInfoPreference, PersonalInfoPreferenceDTO>().ReverseMap();
    }
}
