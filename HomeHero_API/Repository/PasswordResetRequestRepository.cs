using HomeHero_API.Data;
using HomeHero_API.Models;
using HomeHero_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HomeHero_API.Repository
{
    public class PasswordResetRequestRepository : IPasswordResetRequestRepository
    {
        private readonly ApplicationDbContext _context;
        public PasswordResetRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(PasswordResetRequest request)
        {
            _context.PasswordResetRequest.Add(request);
            await _context.SaveChangesAsync();
        }

        public async Task<PasswordResetRequest> GetByCode(string code)
        {
            return await _context.PasswordResetRequest.FirstOrDefaultAsync(e => e.Code == code);
        }

        public async Task Delete(PasswordResetRequest request)
        {
            _context.PasswordResetRequest.Remove(request);
            await _context.SaveChangesAsync();
        }
    }

}
