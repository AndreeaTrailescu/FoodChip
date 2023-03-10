using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Recipes.Queries.GetById
{
    public class GetRecipeByIdQueryHandler : IRequestHandler<GetRecipeByIdQuery, RecipeReadModel>
    {
        private readonly IRecipeRepository _recipeRepository;

        public GetRecipeByIdQueryHandler(
            IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<RecipeReadModel> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
        {
            var recipe = await _recipeRepository.GetById(request.RecipeId, cancellationToken);

            if (recipe == null)
            {
                throw new ObjectNotFoundException(
                    nameof(Recipe),
                    request.RecipeId);
            }

            return recipe;
        }
    }
}
