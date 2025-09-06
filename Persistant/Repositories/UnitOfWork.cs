using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistant.Repositories
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryDbContext _dbContext;

        public UnitOfWork(RepositoryDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
