using HomeHero_API.Models;

namespace HomeHero_API.Repository.IRepository
{
    public interface IPasswordResetRequestRepository
    {
        Task Create(PasswordResetRequest request);
        Task<PasswordResetRequest> GetByCode(string code);
        Task Delete(PasswordResetRequest request);
    }
}
