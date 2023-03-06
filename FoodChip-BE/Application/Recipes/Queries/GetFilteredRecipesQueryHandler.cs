using Application.DTOs;
using Application.Interfaces;
using MediatR;

namespace Application.Recipes.Queries
{
    public class GetFilteredRecipesQueryHandler : IRequestHandler<GetFilteredRecipesQuery, IEnumerable<RecipeReadModel>>
    {
        private readonly IRecipeRepository _recipeRepository;

        public GetFilteredRecipesQueryHandler(
            IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<IEnumerable<RecipeReadModel>> Handle(GetFilteredRecipesQuery request, CancellationToken cancellationToken)
        {
            var recipes = await _recipeRepository.GetFilteredRecipe(request, cancellationToken);

            return recipes;
        }
    }
}
