
using Domain.Categories.Events;
using Domain.SharedKernel.Abstractions;

namespace Domain.Categories
{
    public sealed class Category : Entity
    {
        public Guid CategoryId { get; private set; }
        public string CategoryName { get; private set; }

        private Category(
            Guid categoryId,
            string categoryName) : base(categoryId)

        {
            CategoryName = categoryName;
        }

        //Factoria para el constructor
        public static Category Create(string categoryName)
        {
            var category = new Category(Guid.NewGuid(), categoryName);

            category.RaiseDomainEvents(new CategoryCreateDomainEvent(category.Id));

            return category;
        }

        public void EditCategoryName(string categoryName) 
        {
            CategoryName = categoryName;
        }

    }
}
