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
            .ForMember(dto => dto.RequestPicture, opt => opt.MapFrom(req => Convert.ToBase64String(req.RequestPicture)))
            .ReverseMap()
            .ForMember(req => req.RequestPicture, opt => opt.MapFrom(dto => Convert.FromBase64String(dto.RequestPicture)));
            CreateMap<RequestCreateDto, Request>()
             .ForMember(dest => dest.RequestPicture, opt => opt.MapFrom(src => ConvertFormFileToByteArray(src.RequestPicture)))
             .ReverseMap();

            CreateMap<User, UserSumarryDto>();
            CreateMap<Application, ApplicationCreateDto>().ReverseMap();
            CreateMap<Application, ApplicationDto>().ReverseMap();
        }
        private byte[] ConvertFormFileToByteArray(IFormFile formFile)
        {
            if (formFile == null)
                return null;

            using var memoryStream = new MemoryStream();
            formFile.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }

    }
}
