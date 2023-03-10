using Application.DTOs;
using MediatR;

namespace Application.Recipes.Queries.GetById
{
    public class GetRecipeByIdQuery : IRequest<RecipeReadModel>
    {
        public int RecipeId { get; set; }
    }
}
