using Domain;

namespace Infrastructure.SeedData
{
    public static class RecipeIngredientList
    {
        public static List<RecipeIngredient> GetDefaultRecipeIngredient()
        {
            return new List<RecipeIngredient>
            {
                new RecipeIngredient { RecipeId = 1, IngredientId = 1 },
                new RecipeIngredient { RecipeId = 1, IngredientId = 2 },
                new RecipeIngredient { RecipeId = 1, IngredientId = 3 },
                new RecipeIngredient { RecipeId = 1, IngredientId = 4 },
                new RecipeIngredient { RecipeId = 1, IngredientId = 5 },
                new RecipeIngredient { RecipeId = 1, IngredientId = 6 },
                new RecipeIngredient { RecipeId = 1, IngredientId = 7 },
                new RecipeIngredient { RecipeId = 2, IngredientId = 8 },
                new RecipeIngredient { RecipeId = 2, IngredientId = 1 },
                new RecipeIngredient { RecipeId = 2, IngredientId = 9 },
                new RecipeIngredient { RecipeId = 2, IngredientId = 10 },
                new RecipeIngredient { RecipeId = 2, IngredientId = 4 },
                new RecipeIngredient { RecipeId = 2, IngredientId = 5 },
                new RecipeIngredient { RecipeId = 2, IngredientId = 11 },
                new RecipeIngredient { RecipeId = 3, IngredientId = 12 },
                new RecipeIngredient { RecipeId = 3, IngredientId = 14 },
                new RecipeIngredient { RecipeId = 3, IngredientId = 11 },
                new RecipeIngredient { RecipeId = 3, IngredientId = 4 },
                new RecipeIngredient { RecipeId = 3, IngredientId = 5 },
                new RecipeIngredient { RecipeId = 4, IngredientId = 4 },
                new RecipeIngredient { RecipeId = 4, IngredientId = 15 },
                new RecipeIngredient { RecipeId = 4, IngredientId = 16 },
                new RecipeIngredient { RecipeId = 4, IngredientId = 17 },
                new RecipeIngredient { RecipeId = 4, IngredientId = 6 },
                new RecipeIngredient { RecipeId = 4, IngredientId = 5 },
                new RecipeIngredient { RecipeId = 5, IngredientId = 17 },
                new RecipeIngredient { RecipeId = 5, IngredientId = 18 },
                new RecipeIngredient { RecipeId = 5, IngredientId = 19 },
                new RecipeIngredient { RecipeId = 6, IngredientId = 20 },
                new RecipeIngredient { RecipeId = 6, IngredientId = 15 },
                new RecipeIngredient { RecipeId = 6, IngredientId = 21 },
                new RecipeIngredient { RecipeId = 6, IngredientId = 22 },
                new RecipeIngredient { RecipeId = 6, IngredientId = 18 },
                new RecipeIngredient { RecipeId = 6, IngredientId = 23 },
                new RecipeIngredient { RecipeId = 6, IngredientId = 24 },
                new RecipeIngredient { RecipeId = 6, IngredientId = 4 },
            };
        }
    }
}
