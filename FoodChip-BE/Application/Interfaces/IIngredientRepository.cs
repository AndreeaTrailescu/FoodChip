using Domain;

namespace Application.Interfaces
{
    public interface IIngredientRepository
    {
        Task<IEnumerable<Ingredient>> GetAll(CancellationToken ct);
    }
}
