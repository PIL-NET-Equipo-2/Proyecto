using BrokerBackend.Dtos;
using BrokerBackend.Models;
using BrokerBackend.Repositories;
using System.Net;
using System.Reflection;

namespace BrokerBackend.Services
{
    public class PersonService
    {
        private readonly BrokerContext brokerContext;
        public PersonService(BrokerContext brokerContext)
        {
            this.brokerContext = brokerContext;
        }

        public async Task<List<PersonDto>> GetAll()
        {
            return brokerContext.GetAllPerson().Result.Select(x => x.toDto()).ToList();
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
                Adress = personDto.Adress,
                AccountMoney = personDto.AccountMoney,
                ActiveDate = personDto.ActiveDate,
                InactiveDate = personDto.InactiveDate
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

        public async Task<PersonDto?> Loguin(string usuario, string contrasenia)
        {
            PersonModel? person = await brokerContext.Login(usuario, contrasenia);
            return person?.ToDto();
        }
    }
}
