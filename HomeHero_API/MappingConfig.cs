using AutoMapper;
using HomeHero_API.Models;
using HomeHero_API.Models.Dto;

namespace HomeHero_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {

            CreateMap<Request, RequestUpdateDto>().ReverseMap();
            CreateMap<Request, RequestDto>()
                .ForMember(dest => dest.RequestPicture, opt => opt.Ignore()).ReverseMap();
            CreateMap<RequestCreateDto, Request>()
            .ForMember(dest => dest.RequestPicture, act => act.Ignore()).ReverseMap(); // Ignoramos temporalmente esta propiedad
        }
    }
}
