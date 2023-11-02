using HomeHero_API.Data;
using HomeHero_API.Models;
using HomeHero_API.Repository.IRepository;

namespace HomeHero_API.Repository
{
    public class RequestRepository : Repository<Request>, IRequestRepository
    {
        private readonly ApplicationDbContext _context;
        public RequestRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public int CreateLocation(int locationServiceID, string nameLocation)
        {
            _context.Location.Add(new Location { CityID = locationServiceID , Address = nameLocation });
            _context.SaveChanges();
            return _context.Location.OrderByDescending(l => l.LocationID).FirstOrDefault().LocationID;
        }

        public async Task<Request> Update(HomeHero_API.Models.Request entity)
        {
            entity.UpdateTime = DateTime.Now;
            _context.Request.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
