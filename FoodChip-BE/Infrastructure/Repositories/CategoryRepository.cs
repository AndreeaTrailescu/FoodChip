using Application.Interfaces;
using Domain;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(
            AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAll(CancellationToken ct)
        {
            return await _context.Categories.AsNoTracking()
                .ToListAsync(ct);
        }
    }
}
