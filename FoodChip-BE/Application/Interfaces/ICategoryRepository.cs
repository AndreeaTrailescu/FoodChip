using Domain;

namespace Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll(CancellationToken ct);
        Task<Category?> GetById(int id, CancellationToken ct);
    }
}
