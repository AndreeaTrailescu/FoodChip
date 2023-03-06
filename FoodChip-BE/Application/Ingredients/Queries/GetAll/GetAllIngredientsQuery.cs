using Domain;
using MediatR;

namespace Application.Ingredients.Queries.GetAll
{
    public class GetAllIngredientsQuery : IRequest<IEnumerable<Ingredient>>
    {
    }
}
