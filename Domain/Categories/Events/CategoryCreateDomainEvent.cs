
using Domain.SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Categories.Events
{
    public sealed record CategoryCreateDomainEvent(Guid CategoryId) : IDomainEvent;
}
