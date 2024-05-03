using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Domain.SharedKernel.Abstractions
{
    public interface IDomainEvent : INotification
    {
    }
}
