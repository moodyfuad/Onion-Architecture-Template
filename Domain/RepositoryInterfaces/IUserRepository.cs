using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<bool> RegisterAsync(string email, string password, string name);
    }
}
