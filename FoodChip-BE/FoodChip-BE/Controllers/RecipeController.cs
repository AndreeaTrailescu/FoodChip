using Application.Recipes.Queries;
using AutoMapper;
using FoodChip_BE.DTOs.Recipes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodChip_BE.Controllers
{
    [ApiController]
    [Route("recipes")]
    public class RecipeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public RecipeController(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IEnumerable<RecipeGetModel>> GetFiltered(RecipeSearchModel requestModel)
        {
            var request = _mapper.Map<GetFilteredRecipesQuery>(requestModel);
            var result = await _mediator.Send(request);

            return _mapper.Map<IEnumerable<RecipeGetModel>>(result);
        }
    }
}
