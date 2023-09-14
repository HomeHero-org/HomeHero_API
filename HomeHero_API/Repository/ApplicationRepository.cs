using HomeHero_API.Data;
using HomeHero_API.Models;
using HomeHero_API.Repository.IRepository;

namespace HomeHero_API.Repository
{
    public class ApplicationRepository : Repository<Application>, IApplicationRepository
    {
        private readonly ApplicationDbContext _context;
        public ApplicationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        
    }
}
