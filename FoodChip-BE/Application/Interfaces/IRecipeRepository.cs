using Application.DTOs;
using Application.Recipes.Queries;

namespace Application.Interfaces
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<RecipeReadModel>> GetFilteredRecipe(GetFilteredRecipesQuery request, CancellationToken ct);
    }
}
