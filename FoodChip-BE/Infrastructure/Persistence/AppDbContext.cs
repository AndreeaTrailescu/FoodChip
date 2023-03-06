using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<CookingMethod> CookingMethods { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(attr =>
            {
                attr.HasKey(c => c.Id);

                attr.Property(c => c.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Ingredient>(attr =>
            {
                attr.HasKey(c => c.Id);

                attr.Property(c => c.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<CookingMethod>(attr =>
            {
                attr.HasKey(c => c.Id);

                attr.Property(c => c.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Recipe>(attr =>
            {
                attr.HasKey(c => c.Id);

                attr.Property(c => c.Name).HasMaxLength(50);
                attr.Property(c => c.Description).HasMaxLength(1000);

                attr.HasOne<Category>()
                .WithMany()
                .HasForeignKey(r => r.CategoryId);

                attr.HasOne<CookingMethod>()
                .WithMany()
                .HasForeignKey(r => r.CookingMethodId);
            });

            modelBuilder.Entity<RecipeIngredient>(attr =>
            {
                attr.HasKey(c => new { c.RecipeId, c.IngredientId });

                attr.HasOne<Recipe>()
                .WithMany()
                .HasForeignKey(c => c.RecipeId);

                attr.HasOne<Ingredient>()
                .WithMany()
                .HasForeignKey(c => c.IngredientId);
            });

        }
    }
}
