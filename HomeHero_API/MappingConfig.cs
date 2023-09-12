using AutoMapper;
using HomeHero_API.Models;
using HomeHero_API.Models.Dto;

namespace HomeHero_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {        
            CreateMap<Request, RequestCreateDto>().ReverseMap();
            CreateMap<Request, RequestUpdateDto>().ReverseMap();
            CreateMap<Request, RequestDto>().ReverseMap();
        }
    }
}
