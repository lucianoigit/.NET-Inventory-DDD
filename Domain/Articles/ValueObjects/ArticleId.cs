using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Articles.ValueObjects
{

    public sealed record ArticleId(Guid Value);
}

