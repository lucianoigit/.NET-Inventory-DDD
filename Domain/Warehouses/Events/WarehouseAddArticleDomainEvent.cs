using Domain.SharedKernel.Abstractions;
using Domain.Warehouses.Articles;
using Domain.Warehouses.Articles.ValueObjects;
using Domain.Warehouses.ValueObjects;


namespace Domain.Warehouses.Events
{
    public sealed record WarehouseAddArticleDomainEvent(
    Guid Id,
    Article Article) : IDomainEvent;

}
