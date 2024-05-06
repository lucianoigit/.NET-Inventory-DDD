using Domain.SharedKernel.Abstractions;
using Domain.SharedKernel.Primitives;

namespace Domain.Warehouses.Events
{
    public sealed record WarehouseCreatedDomainEvent(Guid ArticleId) : IDomainEvent;

}
