using Domain.Abstractions;
using Domain.Article.ValueObjects;
using Domain.Warehouse.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Warehouse
{
    public sealed class Warehouse : Entity
    {
        private readonly List<ArticleId> _articleIds = [];
        public Guid WarehouseId { get; private set; }
        public string Adress { get; private set; }

        public IReadOnlyList<ArticleId> ArticleIds => _articleIds.AsReadOnly();


        private Warehouse(Guid warehouseId, string adress) : base(warehouseId)
        {
            Adress = adress;
        }

        public static Warehouse Create(string adress)
        {
            var warehouse = new Warehouse(Guid.NewGuid(), adress);

            warehouse.RaiseDomainEvents(new InventoryCreateDomainEvent(warehouse.Id));

            return warehouse;
        }

        public static 
        
    }
}
