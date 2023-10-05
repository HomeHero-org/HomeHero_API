using AutoMapper;
using HomeHero_API.Data;
using HomeHero_API.Models;
using HomeHero_API.Models.Dto.RequestDto;

namespace HomeHero_API
{
    public class RequestAreaResolver : IValueResolver<Request, RequestDto, string>
    {
        private readonly ApplicationDbContext _context;

        public RequestAreaResolver(ApplicationDbContext context)
        {
            _context = context;
        }

        public string Resolve(Request source, RequestDto destination, string destMember, ResolutionContext context)
        {
            return _context.Area.FirstOrDefault(a => a.AreaID == source.AreaID_Request)?.NameArea;
        }
    }
    public class RequestLocationResolver : IValueResolver<Request, RequestDto, string>
    {
        private readonly ApplicationDbContext _context;

        public RequestLocationResolver(ApplicationDbContext context)
        {
            _context = context;
        }

        public string Resolve(Request source, RequestDto destination, string destMember, ResolutionContext context)
        {
            return "A";
        }
    }



}
