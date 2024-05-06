using Domain.Brands.ValueObjects;
using Domain.Categories.ValueObjects;
using Domain.SharedKernel.Abstractions;
using Domain.Supplier.ValueObjects;
using Domain.Warehouses.Articles.ValueObjects;
using Domain.Warehouses.Events;

namespace Domain.Warehouses.Articles
{
    public sealed class Article : Entity
    {
        private readonly List<SupplierId> _supplierIds = [];

        public Guid ArticleId { get; private set; }
        public string? ArticleBarcode { get; private set; }
        public ArticleCode ArticleCode { get; private set; }
        public string ArticleName { get; private set; }
        public int UnitaryPrice { get; private set; }
        public string ArticleDescription { get; private set; }
        public int Stock { get; private set; }
        public bool IsActive { get; private set; }
        public IReadOnlyList<SupplierId> SupplierIds => _supplierIds.AsReadOnly();
        public CategoryId CategoryId { get; private set; }
        public BrandId BrandId { get; private set; }


        private Article(
         Guid id,
         ArticleCode articleCode,
         string articleBarcode,
         int unitaryPrice,
         string articleDescription,
         int stock,
         bool isActive,
         CategoryId categoryId) : base(id)

        {
            ArticleCode = articleCode;
            ArticleBarcode = articleBarcode;
            UnitaryPrice = unitaryPrice;
            ArticleDescription = articleDescription;
            Stock = stock;
            IsActive = isActive;
            CategoryId = categoryId;

        }

        //Factoria para el constructor
        public static Article Create(
            ArticleCode articleCode,
            string articleBarcode,
            int unitaryPrice,
            string articleDescription,
            int stock,
            bool isActive,
            CategoryId categoryId,
            List<SupplierId>? supplierIds)
        {
            var article = new Article(Guid.NewGuid(), articleCode, articleBarcode, unitaryPrice, articleDescription, stock, isActive, categoryId);

            article.RaiseDomainEvents(new WarehouseCreatedDomainEvent(article.Id));

            return article;
        }
        public void AddCode(ArticleCode articleCode)
        {
            ArticleCode = articleCode;
        }

        public void AddBarCode(string code)
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

        public void IncrementStock(int quantity)
        {
            Stock += quantity;
        }
        public void DecreaseStock(int quantity)
        {
            Stock -= quantity;
        }
        public void RemoveArticle()
        {
            IsActive = false;
        }

        public void AddCategoryId(CategoryId id)
        {
            CategoryId = id;
        }

        public void AddBrandId(BrandId id)
        {
            BrandId = id;
        }

        public void AddSupplierId(SupplierId id)
        {
            // SupplierId = id;
        }



    }



}
