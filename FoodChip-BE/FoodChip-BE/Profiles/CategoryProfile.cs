using AutoMapper;
using Domain;
using FoodChip_BE.DTOs.Category;

namespace FoodChip_BE.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryGetModel>();
        }
    }
}
