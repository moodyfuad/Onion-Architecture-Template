﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    
        public interface IUnitOfWork : IDisposable
        {
            Task<int> SaveChangesAsync(CancellationToken ct = default);
            Task BeginTransactionAsync(CancellationToken ct = default);
            Task CommitTransactionAsync(CancellationToken ct = default);
            Task RollbackTransactionAsync(CancellationToken ct = default);
        }
    }
