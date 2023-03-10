using Domain;
using MediatR;

namespace Application.CookingMethods.Queries.GetAll
{
    public class GetAllCookingMethodsQuery : IRequest<IEnumerable<CookingMethod>>
    {
    }
}
