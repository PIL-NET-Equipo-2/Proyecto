using BrokerApi.Dtos;
using BrokerApi.Models;
using BrokerApi.Repositories;

namespace BrokerApi.Services
{
    public class PersonaService
    {
        private readonly BrokerContext brokerContext;
        public PersonaService(BrokerContext brokerContext)
        {
            this.brokerContext = brokerContext;
        }

        public async Task<List<PersonaDto>> GetAll()
        {
            return brokerContext.GetAllPersona().Result.Select(x => x.toDto()).ToList();
        }
        public async Task<PersonaDto?> Get(int id)
        {
            PersonaModel? persona = await brokerContext.GetPersona(id);
            return persona?.toDto();
        }

        public async Task<PersonaDto?> Create(NewPersonaDto personaDto)
        {
            PersonaModel persona = new PersonaModel
            {
                Nombre = personaDto.Nombre,
                Apellido = personaDto.Apellido,
                Dni = personaDto.Dni,
                FechaNacimiento = personaDto.FechaNacimiento,
                Usuario = personaDto.Usuario,
                Contrasenia = personaDto.Contrasenia,
                FechaAlta = personaDto.FechaAlta,
                FechaBaja = personaDto.FechaBaja,
                IdLocalidad = personaDto.IdLocalidad,
                Roles = personaDto.Roles,
                Cuentas = personaDto.Cuentas
            };

            PersonaModel? result = await brokerContext.CreatePersona(persona);
            return result?.toDto();
        }

        public void Update(int id, string usuario, string contrasenia)
        {
            brokerContext.UpdatePersona(id, usuario, contrasenia);
        }

        public void Delete(int id)
        {
            brokerContext.DeletePersona(id);
        }

        public async Task<PersonaDto?> Loguin(string usuario, string contrasenia)
        {
            PersonaModel? persona = await brokerContext.LoguinPersona(usuario, contrasenia);
            return persona?.toDto();
        }
    }
}
