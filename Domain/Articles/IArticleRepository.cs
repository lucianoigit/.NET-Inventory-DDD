namespace Domain.Articles
{
    internal interface IArticleRepository
    {
        Task<Article> GetByIdAsync(Guid id, CancellationToken cancellationtoken = default);
        Task<List<Article>> GetAllAsync();
        void Add(Article article);
        void Update(Article article);
        void Remove(Article article);
    }
}
