using Domain;

namespace Infrastructure.SeedData
{
    public static class IngredientList
    {
        public static List<Ingredient> GetDefaultIngredients() 
        { 
            return new List<Ingredient>
            {
                new Ingredient { Id = 1, Name = "Butter" },
                new Ingredient { Id = 2, Name = "Broth" },
                new Ingredient { Id = 3, Name = "Broccoli" },
                new Ingredient { Id = 4, Name = "Flour" },
                new Ingredient { Id = 5, Name = "Milk" },
                new Ingredient { Id = 6, Name = "Butter" },
                new Ingredient { Id = 7, Name = "Pepper" },
                new Ingredient { Id = 8, Name = "Bacon" },
                new Ingredient { Id = 9, Name = "Potatoes" },
                new Ingredient { Id = 10, Name = "Green Onions" },
                new Ingredient { Id = 11, Name = "Cheese" },
                new Ingredient { Id = 12, Name = "Ziti Pasta" },
                new Ingredient { Id = 13, Name = "Sour Cream" },
                new Ingredient { Id = 14, Name = "Beef" },
                new Ingredient { Id = 15, Name = "Baking Powder" },
                new Ingredient { Id = 16, Name = "Sugar" },
                new Ingredient { Id = 17, Name = "Salt" },
                new Ingredient { Id = 18, Name = "Eggs" },
                new Ingredient { Id = 19, Name = "White Wine Vinegar" },
                new Ingredient { Id = 20, Name = "Porridge Oats" },
                new Ingredient { Id = 21, Name = "Banana" },
                new Ingredient { Id = 22, Name = "Honey" },
                new Ingredient { Id = 23, Name = "Cinnamon" },
                new Ingredient { Id = 24, Name = "Chocolate Chips" },
            }; 
        }
    }
}
