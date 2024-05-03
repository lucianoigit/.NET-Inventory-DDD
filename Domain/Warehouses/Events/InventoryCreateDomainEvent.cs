using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Warehouse.Events
{
    public sealed record InventoryCreateDomainEvent(Guid warehouseId) : IDomainEvent;
}
