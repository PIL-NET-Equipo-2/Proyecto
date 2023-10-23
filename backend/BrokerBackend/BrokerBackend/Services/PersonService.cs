using BrokerBackend.Dtos;
using BrokerBackend.Models;
using BrokerBackend.Repositories;

namespace BrokerBackend.Services
{
    public class PersonService
    {
        private readonly BrokerContext brokerContext;

        public object Rol { get; private set; }

        public PersonService(BrokerContext brokerContext)
        {
            this.brokerContext = brokerContext;
        }

        public async Task<List<PersonDto>> GetAll()
        {
            return brokerContext.GetAllPerson().Result.Select(x => x.ToDto()).ToList();
        }
        public async Task<PersonDto?> GetById(int id)
        {
            PersonModel? person = await brokerContext.GetPersonById(id);
            return person?.ToDto();
        }

        public async Task<PersonDto?> Create(NewPersonDto personDto)
        {
            PersonModel person = new PersonModel
            {
                Name = personDto.Name,
                Lastname = personDto.Lastname,
                Dni = personDto.Dni,
                Gender = personDto.Gender,
                Mail = personDto.Mail,
                Password = personDto.Password,
                State = personDto.State,
                City = personDto.City,
                Address = personDto.Address,
                AccountMoney = 1000000,
                ActiveDate = personDto.ActiveDate,
                InactiveDate = personDto.InactiveDate,
                IdRol = 2
            };

            PersonModel? result = await brokerContext.CreatePerson(person);
            return result?.ToDto();
        }

        public void Update(int id, string usuario, string contrasenia)
        {
            brokerContext.UpdatePerson(id, usuario, contrasenia);
        }

        public void Delete(int id)
        {
            brokerContext.DeletePerson(id);
        }

        public async Task<PersonDto?> Login(string usuario, string contrasenia)
        {
            PersonModel? person = await brokerContext.Login(usuario, contrasenia);
            return person?.ToDto();
        }
    }
}
