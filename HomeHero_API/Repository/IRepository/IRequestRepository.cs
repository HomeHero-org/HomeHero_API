using HomeHero_API.Models;

namespace HomeHero_API.Repository.IRepository
{
    public interface IRequestRepository : IRepository<Request>
    {
        int CreateLocation(int locationServiceID,string nameLocation);
        Task<Request> Update(Request entity);
    }
}
