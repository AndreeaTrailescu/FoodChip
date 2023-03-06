using Domain;

namespace Application.Interfaces
{
    public interface ICookingMethodRepository
    {
        Task<IEnumerable<CookingMethod>> GetAll(CancellationToken ct);
    }
}
