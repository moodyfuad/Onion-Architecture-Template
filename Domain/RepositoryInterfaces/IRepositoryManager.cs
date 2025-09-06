using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IRepositoryManager
    {
        IPersonRepository PersonRepository { get;  }
        IUnitOfWork UnitOfWork { get; }
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
