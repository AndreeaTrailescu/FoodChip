using Application.Categories.Queries.GetAll;
using AutoMapper;
using FoodChip_BE.DTOs.Category;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodChip_BE.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CategoryController(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryGetModel>> GetAll()
        {
            var query = new GetAllCategoriesQuery();
            var result = await _mediator.Send(query);

            return _mapper.Map<IEnumerable<CategoryGetModel>>(result);
        }
    }
}
