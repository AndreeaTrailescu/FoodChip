using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.CookingMethods.Queries.GetAll
{
    public class GetAllCookingMethodsQueryHandler : IRequestHandler<GetAllCookingMethodsQuery, IEnumerable<CookingMethod>>
    {
        private readonly ICookingMethodRepository _cookingMethodRepository;

        public GetAllCookingMethodsQueryHandler(
            ICookingMethodRepository cookingMethodRepository)
        {
            _cookingMethodRepository = cookingMethodRepository;
        }

        public async Task<IEnumerable<CookingMethod>> Handle(GetAllCookingMethodsQuery request, CancellationToken cancellationToken)
        {
            return await _cookingMethodRepository.GetAll(cancellationToken);
        }
    }
}
