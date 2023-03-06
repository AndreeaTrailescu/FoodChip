using Application.Interfaces;
using Domain;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CookingMethodRepository : ICookingMethodRepository
    {
        private readonly AppDbContext _context;

        public CookingMethodRepository(
            AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CookingMethod>> GetAll(CancellationToken ct)
        {
            return await _context.CookingMethods.AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task<CookingMethod?> GetById(int id, CancellationToken ct)
        {
            return await _context.CookingMethods.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, ct);
        }
    }
}
