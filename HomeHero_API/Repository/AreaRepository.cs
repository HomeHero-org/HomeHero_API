using HomeHero_API.Data;
using HomeHero_API.Models;
using HomeHero_API.Models.Dto.AreaDto;
using HomeHero_API.Repository.IRepository;

namespace HomeHero_API.Repository
{
    public class AreaRepository : IAreaRepository
    {
        private readonly ApplicationDbContext _context;
        public AreaRepository(ApplicationDbContext context) {
            _context = context;
        }
        public bool CreateArea(CreateAreaDto newArea)
        {
            _context.Area.Add(new Area
            {
                NameArea = newArea.NameArea
            });
            return save();
        }

        public bool DeleteArea(Area area)
        {
            _context.Area.Remove(area);
            return save();
        }

        public Area GetArea(int id)
        {
            return _context.Area.FirstOrDefault(a => a.AreaID == id);
        }

        public Area GetArea(string nameArea)
        {
            return _context.Area.FirstOrDefault(a => a.NameArea.Equals(nameArea.Trim()));
        }

        public ICollection<Area> GetAreas()
        {
            return _context.Area.ToList();
        }

        public bool save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateArea(UpdateAreaDto updateArea)
        {
            var area = _context.Area.FirstOrDefault(a => a.NameArea.Equals(updateArea.oldName.Trim()));
            area.NameArea = updateArea.newName;
            return save();
        }
    }
}
