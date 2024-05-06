using Application.Abstractions.Messaging;

namespace Application.Features.Inventory.Warehouses.TransferArticle
{
    public sealed record  TransferArticleCommand(
        string articleCode,
        Guid originWarehouseId,
        Guid destinationWarehouseId,
        int quantity) : ICommand;
}
