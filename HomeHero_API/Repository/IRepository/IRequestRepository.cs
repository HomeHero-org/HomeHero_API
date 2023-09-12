using HomeHero_API.Models;

namespace HomeHero_API.Repository.IRepository
{
    public interface IRequestRepository : IRepository<Request>
    {
        Task<Request> Update(Request entity);
    }
}
