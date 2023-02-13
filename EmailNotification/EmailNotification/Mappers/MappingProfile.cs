using AutoMapper;
using EmailNotification.DTO;
using EmailNotification.Models;

namespace EmailNotification.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmailDto, Email>();
            CreateMap<Email, EmailDto>()
                .ForMember(m => m.CC, m => m.MapFrom(e => e.CC.Split(';', StringSplitOptions.None)))
                .ForMember(m => m.Importance, m => m.MapFrom(e => ((Importance)e.Importance).ToString()));
        }
    }
}
