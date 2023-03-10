using FoodChip_BE.DTOs.Ingredients;

namespace FoodChip_BE.DTOs.Recipes
{
    public class RecipeGetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string CookingMethod { get; set; }
        public IEnumerable<IngredientGetModel> Ingredients { get; set; }
        public string? Photo { get; set; }
    }
}
