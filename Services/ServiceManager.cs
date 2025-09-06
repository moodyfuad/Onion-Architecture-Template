using Domain.RepositoryInterfaces;
using Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IPersonServices> _lazyPersonServices;
        public IPersonServices PersonServices => _lazyPersonServices.Value;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyPersonServices = new Lazy<IPersonServices>(() => new PersonServices(repositoryManager));
        }
    }
}
