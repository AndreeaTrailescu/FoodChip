using Application.DTOs;
using MediatR;

namespace Application.Recipes.Queries.GetFiltered
{
    public class GetFilteredRecipesQuery : IRequest<IEnumerable<RecipeReadModel>>
    {
        public int? CategoryId { get; set; }
        public int? CookingMethodId { get; set; }
        public IList<int>? IngredientIds { get; set; }
    }
}
