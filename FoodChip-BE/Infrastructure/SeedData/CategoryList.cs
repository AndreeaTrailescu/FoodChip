using Domain;

namespace Infrastructure.SeedData
{
    public static class CategoryList
    {
        public static List<Category> GetDefaultCategories()
        {
            return new List<Category>()
            {
                new Category { Id = 1, Name = "Breakfast Recipes" },
                new Category { Id = 2, Name = "Dinner Recipes" },
                new Category { Id = 3, Name = "Lunch Recipes" },
            };
        }
    }
}
