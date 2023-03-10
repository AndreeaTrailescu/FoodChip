using Application.DTOs;
using Application.Interfaces;
using Application.Recipes.Queries;
using Domain;
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

        public async Task<IEnumerable<RecipeReadModel>> GetFilteredRecipe(GetFilteredRecipesQuery request, CancellationToken ct)
        {
            var result = _context.Recipes.AsNoTracking()
                .Select(x => new RecipeReadModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description= x.Description,
                    CategoryId= x.CategoryId,
                    CookingMethodId = x.CookingMethodId,
                });

            Category? category = null;
            CookingMethod? cookingMethod = null;

            if (request.CategoryId.HasValue)
            {
                result = result.Where(x => x.CategoryId == request.CategoryId.Value);
                category = _context.Categories.AsNoTracking()
                    .FirstOrDefault(x => x.Id == request.CategoryId.Value);
            }

            if (request.CookingMethodId.HasValue)
            {
                result = result.Where(x => x.CookingMethodId == request.CookingMethodId.Value);
                cookingMethod = _context.CookingMethods.AsNoTracking()
                    .FirstOrDefault(x => x.Id == request.CookingMethodId.Value);
            }

            if (request.IngredientIds != null && request.IngredientIds.Count > 0)
            {
                var ingredients = from ir in _context.RecipeIngredients.AsNoTracking()
                                  join ingredient in _context.Ingredients.AsNoTracking()
                                  on ir.IngredientId equals ingredient.Id
                                  select new {ir.RecipeId, ingredient};

             result = result
                .Where(r => _context.RecipeIngredients
                    .Where(ri => request.IngredientIds.Contains(ri.IngredientId))
                    .Select(ri => ri.RecipeId)
                    .Contains(r.Id))
                .Select(r => new RecipeReadModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    CategoryId = r.CategoryId,
                    Category = category.Name,
                    CookingMethodId = r.CookingMethodId,
                    CookingMethod = cookingMethod.Name,
                    Ingredients = ingredients
                        .Where(ri => ri.RecipeId == r.Id)
                        .Select(ri => new Ingredient { Id = ri.ingredient.Id, Name = ri.ingredient.Name })
                        .ToList()
                });
            }

            return await result.ToListAsync(ct);
        }
    }
}
