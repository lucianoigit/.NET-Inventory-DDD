using Domain.SharedKernel.Abstractions;
using Domain.SharedKernel.Primitives;
using Domain.Warehouses.Articles;
using Domain.Warehouses.Articles.ValueObjects;
using Domain.Warehouses.Events;
using Domain.Warehouses.ValueObjects;
using System.Linq;

namespace Domain.Warehouses;

public sealed class Warehouse : Entity
{
    private readonly List<Article> _articles = [];

    public string Address { get; private set; } = default!;

    public IReadOnlyList<Article> Articles => _articles.AsReadOnly();
    private Warehouse() { }
    private Warehouse(
        Guid id,
        string address) : base(id)
    {
        Address = address;
    }

    

    public static Warehouse Create(string address)
    {
        var warehouse = new Warehouse(
            Guid.NewGuid(),
            address);

        warehouse.RaiseDomainEvents(new WarehouseCreateDomainEvent(warehouse.Id));

        return warehouse;
    }

    public Article? GetArticleByCode(ArticleCode articleCode)
    {
        return _articles.FirstOrDefault(a => a.ArticleCode == articleCode);
    }

    public Result AddArticle(Article article)
    {
        if (_articles.Contains(article))
            return Result.Failure(WarehouseErrors.ArticletAlreadyExists);

        _articles.Add(article);

        this.RaiseDomainEvents(new WarehouseAddArticleDomainEvent(Guid.NewGuid(), article));

        return Result.Success();
    }


    public IReadOnlyList<Article> GetArticles()
    {
        return Articles;
    }



    public void IncrementArticleByCode(ArticleCode articleCode,int quantity)
    {
        var article = GetArticleByCode(articleCode);

        if (article is null) return;
        
        article.IncrementStock(quantity);
    }
    public void DecreaseArticleByCode(ArticleCode articleCode, int quantity)
    {
        var article = GetArticleByCode(articleCode);
        if (article is not null)
        {
            article.DecreaseStock(quantity);
        }
    }
}
