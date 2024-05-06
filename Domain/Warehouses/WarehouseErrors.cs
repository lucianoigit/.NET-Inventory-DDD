using Domain.SharedKernel.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Warehouses
{
    public static class WarehouseErrors
    {
        public static Error WarehousetNotFound = Error.NotFound("warehouse.NotFound", "The article was not found");
        public static Error ArticleNotFound = Error.NotFound("Warehouse.article", "The warehouse articleId was not found");
        public static Error ArticletAlreadyExists = Error.Validation("warehouse.ArticleAlreadyExists", "The article is already present in the product.");
    }
}
