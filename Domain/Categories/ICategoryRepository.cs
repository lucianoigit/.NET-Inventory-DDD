namespace Domain.Categories
{
    internal interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(Guid id, CancellationToken cancellationtoken = default);
        Task<List<Category>> GetAllAsync();
        void Add(Category brand);
        void Update(Category brand);
        void Remove(Category brand);
    }
}
