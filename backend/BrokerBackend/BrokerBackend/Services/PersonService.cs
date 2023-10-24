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

        /// <summary>
        /// Metodo que trae todas las personas registradas en el sistema
        /// </summary>
        /// <returns>Listado de todas las personas registradas</returns>
        public async Task<List<PersonDto>> GetAll()
        {
            return brokerContext.GetAllPerson().Result.Select(x => x.ToDto()).ToList();
        }

        /// <summary>
        /// Trae una persona por su id
        /// </summary>
        /// <param name="id">ID de la persona a traer</param>
        /// <returns>El DTO de la persona</returns>
        public async Task<PersonDto?> GetById(int id)
        {
            PersonModel? person = await brokerContext.GetPersonById(id);
            return person?.ToDto();
        }

        /// <summary>
        /// Permite crear una nueva persona
        /// </summary>
        /// <param name="personDto">DTO de la persona a crear</param>
        /// <returns>La persona que se agregara</returns>
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

        /// <summary>
        /// Metodo que permite actualizar una persona
        /// </summary>
        /// <param name="id">ID de la persona a modificar</param>
        /// <param name="usuario">Usuario de la persona a modificar</param>
        /// <param name="contrasenia">Contraseña de la persona a modificar</param>
        public void Update(int id, string usuario, string contrasenia)
        {
            brokerContext.UpdatePerson(id, usuario, contrasenia);
        }

        /// <summary>
        /// Metodo que permite eliminar una persona
        /// </summary>
        /// <param name="id">ID de la persona a eliminar</param>
        public void Delete(int id)
        {
            brokerContext.DeletePerson(id);
        }

        /// <summary>
        /// Permite loguearse en el sistema
        /// </summary>
        /// <param name="usuario">Usuario de la persona que se loguea</param>
        /// <param name="contrasenia">Contraseña de la persona que se loguea</param>
        /// <returns></returns>
        public async Task<PersonDto?> Login(string usuario, string contrasenia)
        {
            PersonModel? person = await brokerContext.Login(usuario, contrasenia);
            return person?.ToDto();
        }
    }
}
