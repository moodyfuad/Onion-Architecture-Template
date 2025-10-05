using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistant.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryDbContext _dbContext;

        private readonly Lazy<IPersonRepository> _lazyPersonRepository;
        public IPersonRepository PersonRepository => _lazyPersonRepository.Value;

        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;


        public RepositoryManager(RepositoryDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _lazyPersonRepository ??= new Lazy<IPersonRepository>(() => new PersonRepository(_dbContext));
            _lazyUnitOfWork ??= new Lazy<IUnitOfWork>(() => new UnitOfWork(_dbContext));
        }


    
    }
}
