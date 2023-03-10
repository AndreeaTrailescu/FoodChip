using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Recipes.Queries.GetFiltered
{
    public class GetFilteredRecipesQueryHandler : IRequestHandler<GetFilteredRecipesQuery, IEnumerable<RecipeReadModel>>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICookingMethodRepository _cookingMethodRepository;

        public GetFilteredRecipesQueryHandler(
            IRecipeRepository recipeRepository,
            ICategoryRepository categoryRepository,
            ICookingMethodRepository cookingMethodRepository)
        {
            _recipeRepository = recipeRepository;
            _categoryRepository = categoryRepository;
            _cookingMethodRepository = cookingMethodRepository;
        }

        public async Task<IEnumerable<RecipeReadModel>> Handle(GetFilteredRecipesQuery request, CancellationToken cancellationToken)
        {
            if (request.CategoryId.HasValue)
            {
                _ = await _categoryRepository.GetById(request.CategoryId.Value, cancellationToken)
                    ?? throw new ObjectNotFoundException(
                        nameof(Category),
                        request.CategoryId.Value);
            }

            if (request.CookingMethodId.HasValue)
            {
                _ = await _cookingMethodRepository.GetById(request.CookingMethodId.Value, cancellationToken)
                    ?? throw new ObjectNotFoundException(
                        nameof(CookingMethod),
                        request.CookingMethodId.Value);
            }

            var recipes = await _recipeRepository.GetFilteredRecipe(request, cancellationToken);

            return recipes;
        }
    }
}
