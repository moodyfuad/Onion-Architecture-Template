using Domain.RepositoryInterfaces;
using Microsoft.AspNetCore.Identity;
using Persistant.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistant.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            
            _userManager = userManager;
        }
        //public UserRepository(UserManager<ApplicationUser> userManager)
        //{
        //    _userManager = userManager;
        //}

        public async Task<bool> RegisterAsync(string email, string password, string name)
        {
            var appUser = new ApplicationUser
            {
                
                UserName = email,
                Email = email,
                Name = name
            };

            var result = await _userManager.CreateAsync(appUser, password);

            if (!result.Succeeded)
                return false;

            return true;
        }
    }
}
