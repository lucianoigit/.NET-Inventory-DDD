﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SharedKernel.Abstractions
{
    public interface IUnitOfWork
    {
        Task<int> SaveCHangesAsync(CancellationToken cancellationtoken = default);
    }
}
