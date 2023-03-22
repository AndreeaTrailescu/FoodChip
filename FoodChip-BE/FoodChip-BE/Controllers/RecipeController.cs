using Application.Recipes.Queries.GetById;
using Application.Recipes.Queries.GetFiltered;
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

        [HttpGet]
        public async Task<IEnumerable<RecipeGetModel>> GetFiltered([FromQuery]RecipeSearchModel requestModel)
        {
            var request = _mapper.Map<GetRecipesQuery>(requestModel);
            var result = await _mediator.Send(request);

            return _mapper.Map<IEnumerable<RecipeGetModel>>(result);
        }

        [HttpGet]
        [Route("{recipeId}")]
        public async Task<RecipeGetModel> GetById(int recipeId)
        {
            var query = new GetRecipeByIdQuery { RecipeId = recipeId };
            var result = await _mediator.Send(query);

            return _mapper.Map<RecipeGetModel>(result);
        }
    }
}
