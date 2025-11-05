using Domain.RepositoryInterfaces;
using Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserServices : IUserServices
    {
        private readonly IRepositoryManager _repos;

        public UserServices(IRepositoryManager repos)
        {
            _repos = repos;
        }


        public Task<bool> RegisterAsync(string email, string password, string name)
        {
            _repos.UserRepository.RegisterAsync(email, password, name);
        }
    }
}
