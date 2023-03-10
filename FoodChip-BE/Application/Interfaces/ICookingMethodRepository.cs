using Domain;

namespace Application.Interfaces
{
    public interface ICookingMethodRepository
    {
        Task<IEnumerable<CookingMethod>> GetAll(CancellationToken ct);
        Task<CookingMethod?> GetById(int id, CancellationToken ct);
    }
}
