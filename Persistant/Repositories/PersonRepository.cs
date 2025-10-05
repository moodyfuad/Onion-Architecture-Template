using Domain.Entities;
using Domain.Exceptions;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistant.Repositories
{
    internal sealed class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        private readonly RepositoryDbContext _dbContext;
        private readonly RepositoryDbContext _dbSet;

        public PersonRepository(RepositoryDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task AddPersonAsync(Person person, CancellationToken cancellationToken = default)
        {
             await _dbContext.Persons.AddAsync(person, cancellationToken);
        }

        public async Task DeleteAsync(Guid id)
        {
             _dbContext.Persons.Remove(_dbContext.Persons.Find(id));
        }

        public async Task<IEnumerable<Person>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Persons.ToListAsync(cancellationToken);
        }

        public async Task<Person> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Persons.FindAsync(id, cancellationToken)??throw new PersonNotFoundException(id);
        }

        public async Task UpdateAsync(Person person)
        {
            _dbContext.Persons.Update(person);
        }
    }
}
