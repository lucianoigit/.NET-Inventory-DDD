using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Inventory.Articles.Add
{
    public sealed record AddArticleCommand(
        Guid WarehouseId,
        string ArticleCode,
        string ArticleBarcode,
        int UnitaryPrice,
        string ArticleDescription,
        int Stock,
        Guid CategoryId,
        List<Guid>? SupplierIds) : ICommand;
}
