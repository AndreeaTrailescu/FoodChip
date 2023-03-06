namespace FoodChip_BE.DTOs.Recipes
{
    public class RecipeSearchModel
    {
        public int? CategoryId { get; set; }
        public int? CookingMethodId { get; set; }
        public IList<int>? IngredientIds { get; set; }
    }
}
