using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SeedData
{
    public static class ModelBuilderExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(CategoryList.GetDefaultCategories());

            modelBuilder.Entity<CookingMethod>()
                .HasData(CookingMethodList.GetDefaultCookingMethods());

            modelBuilder.Entity<Ingredient>()
                .HasData(IngredientList.GetDefaultIngredients());

            modelBuilder.Entity<Recipe>()
                .HasData(RecipeList.GetDefaultRecipes());

            modelBuilder.Entity<RecipeIngredient>()
                .HasData(RecipeIngredientList.GetDefaultRecipeIngredient());
        }
    }
}
