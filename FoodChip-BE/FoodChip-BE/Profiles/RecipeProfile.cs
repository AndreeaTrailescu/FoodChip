using Application.DTOs;
using Application.Recipes.Queries;
using AutoMapper;
using FoodChip_BE.DTOs.Recipes;

namespace FoodChip_BE.Profiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<RecipeReadModel, RecipeGetModel>();
            CreateMap<RecipeSearchModel, GetFilteredRecipesQuery>();
        }
    }
}
