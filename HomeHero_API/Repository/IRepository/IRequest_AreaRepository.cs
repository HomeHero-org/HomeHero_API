using HomeHero_API.Models.Dto.AreaDto;
using HomeHero_API.Models;
using HomeHero_API.Models.Dto.Request_AreaDto;

namespace HomeHero_API.Repository.IRepository
{
    public interface IRequest_AreaRepository
    {
        ICollection<Request_Area> GetRequests_Areas();
        Request_Area GetRA(int id);
        ICollection<Request_Area> GetRequestByArea(string areaName);
        ICollection<Request_Area> GetAreasByRequest(int requestID);
        bool DeleteRA(Request_Area request_Area);
        bool ExistRA(CreateRequest_AreaDto request_Area);
        bool save();
        bool CreateRA(CreateRequest_AreaDto newRA);
        int lastID();
    }
}
