using Domain.Categories.ValueObjects;

namespace Domain.Categories
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(CategoryId id, CancellationToken cancellationtoken = default);
        Task<List<Category>> GetAllAsync();
        void Add(Category brand);
        void Update(Category brand);
        void Remove(Category brand);
    }
}
