using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Inventory.Articles.Add
{
    public sealed record AddArticleRequest(
        Guid id,
        int quantity);
}
