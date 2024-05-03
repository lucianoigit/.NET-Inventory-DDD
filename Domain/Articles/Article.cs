using Domain.Articles.Events;
using Domain.Articles.ValueObjects;
using Domain.Brands.ValueObjects;
using Domain.Categories.ValueObjects;
using Domain.SharedKernel.Abstractions;

namespace Domain.Articles
{
    public sealed class Article : Entity
    {
        public Guid ArticleId { get; private set; }
        public int? ArticleBarcode { get; private set; }
        public Sku Sku { get; private set; }
        public string ArticleName { get; private set; }
        public int UnitaryPrice { get; private set; }
        public string ArticleDescription { get; private set; }
        public int Stock { get; private set; }
        public bool ArticleState { get; private set; }
        public ProviderId ProviderId { get; private set; }
        public CategoryId CategoryId { get; private set; }
        public BrandId BrandId { get; private set; }
        public DateTime? LastArticleOnUtc { get; private set; }

        private Article(
         Guid id,
         Sku sku,
         int articleBarcode,
         int unitaryPrice,
         string articleDescription,
         int stock,
         bool articleState,
         ProviderId providerId,
         CategoryId categoryId) : base(id)

        {
            Sku = sku;
            ArticleBarcode = articleBarcode;
            UnitaryPrice = unitaryPrice;
            ArticleDescription = articleDescription;
            Stock = stock;
            ArticleState = articleState;
            ProviderId = providerId;
            CategoryId = categoryId;

        }

        //Factoria para el constructor
        public static Article Create(Sku sku, int articleBarcode, int unitaryPrice, string articleDescription, int stock, bool articleState, ProviderId providerId, CategoryId categoryId)
        {
            var article = new Article(Guid.NewGuid(), sku, articleBarcode, unitaryPrice, articleDescription, stock, articleState, providerId, categoryId);

            article.RaiseDomainEvents(new ArticleCreatedDomainEvent(article.Id));

            return article;
        }

        public void AddBarCode(int code)
        {
            ArticleBarcode = code;
        }

        public void DeleteBarCode()
        {
            ArticleBarcode = null;
        }
        public void EditUnitaryPrice(int price)
        {
            UnitaryPrice = price;
        }
        public void EditArticleDescription(string description) 
        {
            ArticleDescription = description;
        }

        public void AddStock(int quantity)
        {
            Stock += quantity;
        }
        public void RemoveStock(int quantity)
        { 
            Stock -= quantity;
        }

        public void AddCategoryId(CategoryId id)
        { 
            CategoryId = id;         
        }

        public void AddBrandId(BrandId id) 
        {
            BrandId = id;
        }

        public void AddProviderId(ProviderId id)
        { 
            ProviderId = id;
        }



    }



}
