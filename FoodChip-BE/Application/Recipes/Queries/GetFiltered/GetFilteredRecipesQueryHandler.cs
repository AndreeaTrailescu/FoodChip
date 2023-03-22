using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Domain;
using Domain.Inference;
using MediatR;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Application.Recipes.Queries.GetFiltered
{
    public class GetFilteredRecipesQueryHandler : IRequestHandler<GetRecipesQuery, IEnumerable<RecipeReadModel>>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICookingMethodRepository _cookingMethodRepository;
        private readonly IIngredientRepository _ingredientRepository;
        public GetFilteredRecipesQueryHandler(
            IRecipeRepository recipeRepository,
            ICategoryRepository categoryRepository,
            ICookingMethodRepository cookingMethodRepository,
            IIngredientRepository ingredientRepository)
        {
            _recipeRepository = recipeRepository;
            _categoryRepository = categoryRepository;
            _cookingMethodRepository = cookingMethodRepository;
            _ingredientRepository = ingredientRepository;
        }

        public async Task<IEnumerable<RecipeReadModel>> Handle(GetRecipesQuery request, CancellationToken cancellationToken)
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

            var engine = new InferenceEngine();

            var allMethodCooking = await _cookingMethodRepository.GetAll(cancellationToken);
            var allCategories = await _categoryRepository.GetAll(cancellationToken);
            var recipes = await _recipeRepository.GetAll(request, cancellationToken);
            var ingredients = await _ingredientRepository.GetAll(cancellationToken);

            int category = 0;
            int cooking = 0;
            int[] ingredientIds = new int[0];
            Fact f1, f2;
            Fact[] ingredientFacts;

            if (request.CategoryId.HasValue)
            {
                category = request.CategoryId.Value;
            }

            if (request.CookingMethodId.HasValue)
            {
                cooking = request.CookingMethodId.Value;
            }

            if (request.IngredientIds != null && request.IngredientIds.Any())
            {
                ingredientIds = request.IngredientIds.ToArray();
            }

            if (category >= 1)
            {
                var cat = await _categoryRepository.GetById(category, cancellationToken);
                f1 = new Fact("category", value: cat.Name);
                engine.AddFact(f1);
            }

            if(cooking >= 1)
            {
                var cook = await _cookingMethodRepository.GetById(cooking, cancellationToken);
                f2 = new Fact("cooking method", value: cook.Name);
                engine.AddFact(f2);
            }

            if (ingredientIds.Length > 0)
            {
                ingredientFacts = new Fact[ingredientIds.Length];
                for (int i = 0; i < ingredientIds.Length; i++)
                {
                    var ingName = ingredients.FirstOrDefault(l => l.Id == ingredientIds[i]);
                    if(ingName != null)
                    {
                        ingredientFacts[i] = new Fact("ingredient", value: ingName.Name);
                        engine.AddFact(ingredientFacts[i]);
                    }
                }
            }

            var derivedFacts = engine.Run().ToList();
            foreach(var f in derivedFacts)
            {
                System.Console.WriteLine(f.Name + " " + f.Value);
            }

            var inferredRecipes = derivedFacts
                .Where(f => f.Name == "recipe")
                .Select(f => recipes.FirstOrDefault(r => r.Name == f.Value))
                .Where(r => r != null);

            return inferredRecipes;
        }
    }
}
