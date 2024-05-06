using Domain.Articles.ValueObjects;
using Domain.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Warehouses.ValueObjects;

namespace Domain.Warehouses
{
    public interface IWarehouseRepository
    {
        Task<Warehouse?> GetByIdAsync(WareHouseId id, CancellationToken cancellationtoken = default);
        Task<List<Warehouse>> GetAllAsync();
        void Add(Warehouse warehouse);
        void Update(Warehouse warehouse);
        void Remove(Warehouse warehouse);
    }
}
