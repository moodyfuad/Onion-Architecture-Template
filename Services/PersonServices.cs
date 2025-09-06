using Domain.Entities;
using Domain.Exceptions;
using Domain.RepositoryInterfaces;
using Service.Abstraction;
using Shared;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class PersonServices : IPersonServices
    {
        private readonly IRepositoryManager repositoryManager;

        public PersonServices(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<PersonDto> CreatePerson(PersonDto personDto, CancellationToken cancellationToken = default)
        {
            Person person = new ()
            {
                Id = personDto.Id,
               Name = personDto.Name,
                
            };
            await repositoryManager.PersonRepository.AddPersonAsync(person);
            await repositoryManager.SaveAsync(cancellationToken);
            return personDto;
        }

        public async Task DeletePerson(Guid id, CancellationToken cancellationToken = default)
        {
            await repositoryManager.PersonRepository.DeleteAsync(id);
        }

        public async Task<PersonDto> GetPersonById(Guid id, CancellationToken cancellationToken = default)
        {
            var person = await repositoryManager.PersonRepository.GetByIdAsync(id, cancellationToken);

            if (person is null)
            {
                throw new PersonNotFoundException(id);
            }
            return new PersonDto
            {
                Id = person.Id,
                Name = person.Name,
                
            };
        }

        public async Task<IEnumerable<PersonDto>> GetPersons(CancellationToken cancellationToken = default)
        {
            return (await repositoryManager.PersonRepository.GetAllAsync(cancellationToken)).Select(person => new PersonDto
            {
                Id = person.Id,
                Name = person.Name,
                
            });
        }

        public async Task<PersonDto> UpdatePerson(Guid id, PersonDto personDto, CancellationToken cancellationToken = default)
        {
            var person = await repositoryManager.PersonRepository.GetByIdAsync(id, cancellationToken) ?? throw new PersonNotFoundException(id);

            // Update the person entity with values from personDto
            person.Name = personDto.Name;

            await repositoryManager.PersonRepository.UpdateAsync(person);

            return new PersonDto
            {
                Id = person.Id,
                Name = person.Name,
            };
        }
    }
}
