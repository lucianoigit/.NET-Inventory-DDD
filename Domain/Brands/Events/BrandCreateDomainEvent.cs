using Domain.SharedKernel.Abstractions;

namespace Domain.Brands.Events
{
    public sealed record BrandCreateDomainEvent(Guid brandId) : IDomainEvent;
}
