
using Domain.SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Warehouses.Events
{
    public sealed record WarehouseCreateDomainEvent(Guid warehouseId) : IDomainEvent;
}
