using HomeHero_API.Models.Dto.AreaDto;
using HomeHero_API.Models;
namespace HomeHero_API.Repository.IRepository
{
    public interface IAreaRepository
    {
        ICollection<Area> GetAreas();
        Area GetArea(int id);
        Area GetArea(string nameArea);
        bool DeleteArea(Area area);
        bool UpdateArea(UpdateAreaDto updateArea);
        bool save();
        bool CreateArea(CreateAreaDto newArea);
    }
}
