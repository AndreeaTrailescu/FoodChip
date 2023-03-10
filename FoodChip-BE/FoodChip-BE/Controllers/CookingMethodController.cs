using Application.CookingMethods.Queries.GetAll;
using AutoMapper;
using FoodChip_BE.DTOs.CookingMethod;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodChip_BE.Controllers
{
    [ApiController]
    [Route("cooking-methods")]
    public class CookingMethodController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CookingMethodController(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<CookingMethodGetModel>> GetAll()
        {
            var query = new GetAllCookingMethodsQuery();
            var result = await _mediator.Send(query);

            return _mapper.Map<IEnumerable<CookingMethodGetModel>>(result);
        }
    }
}
