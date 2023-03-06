using Application.Ingredients.Queries.GetAll;
using AutoMapper;
using FoodChip_BE.DTOs.Ingredients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodChip_BE.Controllers
{
    [ApiController]
    [Route("ingredients")]
    public class IngredientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public IngredientController(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<IngredientGetModel>> GetAll()
        {
            var query = new GetAllIngredientsQuery();
            var result = await _mediator.Send(query);

            return _mapper.Map<IEnumerable<IngredientGetModel>>(result);
        }
    }
}
