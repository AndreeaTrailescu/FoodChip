using Domain;

namespace Infrastructure.SeedData
{
    public class CookingMethodList
    {
        public static List<CookingMethod> GetDefaultCookingMethods()
        {
            return new List<CookingMethod>
            {
                new CookingMethod { Id = 1, Name = "Baking" },
                new CookingMethod { Id = 2, Name = "Boiling" },
            };
        }
    }
}
