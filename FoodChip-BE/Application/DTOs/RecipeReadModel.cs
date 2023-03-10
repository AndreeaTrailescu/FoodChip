using Domain;

namespace Application.DTOs
{
    public class RecipeReadModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Photo { get; set; }
        public int CategoryId { get; set; }
        public string? Category { get; set; }
        public int CookingMethodId { get; set; }
        public string? CookingMethod { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
    }
}
