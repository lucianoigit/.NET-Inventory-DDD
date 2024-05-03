namespace Domain.Brands
{
    internal interface IBrandRepository
    {
        Task<Brand> GetByIdAsync(Guid id, CancellationToken cancellationtoken = default);
        Task<List<Brand>> GetAllAsync();
        void Add(Brand brand);
        void Update(Brand brand);
        void Remove(Brand brand);

    }
}
