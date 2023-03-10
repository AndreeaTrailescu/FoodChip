using AutoMapper;
using Domain;
using FoodChip_BE.DTOs.Ingredients;

namespace FoodChip_BE.Profiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Ingredient, IngredientGetModel>();
        }
    }
}
