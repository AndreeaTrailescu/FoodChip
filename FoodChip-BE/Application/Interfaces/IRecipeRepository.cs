using Application.DTOs;
using Application.Recipes.Queries.GetFiltered;

namespace Application.Interfaces
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<RecipeReadModel>> GetFilteredRecipe(GetFilteredRecipesQuery request, CancellationToken ct);
        Task<RecipeReadModel?> GetById(int recipeId, CancellationToken ct);
    }
}
