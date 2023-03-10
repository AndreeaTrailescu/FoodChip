using Application.Interfaces;
using Domain;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly AppDbContext _context;

        public IngredientRepository(
            AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ingredient>> GetAll(CancellationToken ct)
        {
            return await _context.Ingredients.AsNoTracking()
                .ToListAsync(ct);
        }
    }
}
