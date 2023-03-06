using Domain;
using MediatR;

namespace Application.Categories.Queries.GetAll
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<Category>>
    {
    }
}
