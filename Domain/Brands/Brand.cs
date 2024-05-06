
using Domain.Brands.Events;
using Domain.SharedKernel.Abstractions;

namespace Domain.Brands
{
    public sealed class Brand : Entity
    {
        public Guid BrandId { get; private set; }
        public string BrandName { get; private set; }

        private Brand(
           Guid id,
           string BrandName) : base(id)

        { 
        BrandId = id;
        }

        public static Brand Create(string brandName) 
        {
            var brand = new Brand(Guid.NewGuid(), brandName);

            brand.RaiseDomainEvents(new BrandCreateDomainEvent(brand.Id));

            return brand;
        }

        public void EditBrandName(string brandName)
        {
            BrandName = brandName;
        }

    }

    
}
