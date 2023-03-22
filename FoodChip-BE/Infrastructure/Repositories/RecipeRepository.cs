using Application.DTOs;
using Application.Interfaces;
using Application.Recipes.Queries.GetFiltered;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly AppDbContext _context;

        public RecipeRepository(
            AppDbContext context)
        {
            _context = context;
        }

        public async Task<RecipeReadModel?> GetById(int recipeId, CancellationToken ct)
        {
            var ingredients = from ir in _context.RecipeIngredients.AsNoTracking().Where(x => x.RecipeId == recipeId)
                              join ingredient in _context.Ingredients.AsNoTracking()
                              on ir.IngredientId equals ingredient.Id
                              select ingredient;

            var recipe = from rec in _context.Recipes.AsNoTracking().Where(x => x.Id == recipeId)
                         join category in _context.Categories.AsNoTracking()
                         on rec.CategoryId equals category.Id
                         join cookingMethod in _context.CookingMethods.AsNoTracking()
                         on rec.CookingMethodId equals cookingMethod.Id
                         select new RecipeReadModel
                         {
                             Id = rec.Id,
                             Name = rec.Name,
                             Photo = rec.Photo,
                             Description = rec.Description,
                             CategoryId = rec.CategoryId,
                             Category = category.Name,
                             CookingMethodId = rec.CookingMethodId,
                             CookingMethod = cookingMethod.Name,
                             Ingredients = ingredients,
                         };

            return await recipe.FirstOrDefaultAsync(ct);
        }

        public async Task<IEnumerable<RecipeReadModel>> GetAll(GetRecipesQuery request, CancellationToken ct)
        {
            var recipes = _context.Recipes.AsNoTracking()
                .Select(x => new RecipeReadModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Photo = x.Photo,
                    Description = x.Description,
                    CategoryId = x.CategoryId,
                    CookingMethodId = x.CookingMethodId,
                });

            return await recipes.ToListAsync(ct);
        }
    }
}
