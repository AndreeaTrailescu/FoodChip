using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Ingredients.Queries.GetAll
{
    public class GetAllIngredientsQueryHandler : IRequestHandler<GetAllIngredientsQuery, IEnumerable<Ingredient>>
    {
        private readonly IIngredientRepository _ingredientRepository;

        public GetAllIngredientsQueryHandler(
            IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public async Task<IEnumerable<Ingredient>> Handle(GetAllIngredientsQuery request, CancellationToken cancellationToken)
        {
            return await _ingredientRepository.GetAll(cancellationToken);
        }
    }
}
