using AutoMapper;
using Domain;
using FoodChip_BE.DTOs.CookingMethod;

namespace FoodChip_BE.Profiles
{
    public class CookingMethodProfile : Profile
    {
        public CookingMethodProfile()
        {
            CreateMap<CookingMethod, CookingMethodGetModel>();
        }
    }
}
