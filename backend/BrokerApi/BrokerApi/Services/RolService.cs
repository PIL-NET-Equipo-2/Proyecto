using BrokerApi.Dtos;
using BrokerApi.Models;
using BrokerApi.Repositories;

namespace BrokerApi.Services
{
    public class RolService
    {
        private readonly BrokerContext brokerContext;
        public RolService(BrokerContext brokerContext)
        {
            this.brokerContext = brokerContext;
        }

        public async Task<List<RolDto>> GetAll()
        {
            return brokerContext.GetAllRol().Result.Select(x => x.toDto()).ToList();
        }
        public async Task<RolDto?> Get(int id)
        {
            RolModel? rol = await brokerContext.GetRol(id);
            return rol?.toDto();
        }

        public async Task<RolDto?> Create(NewRolDto rolDto)
        {
            RolModel rol = new RolModel
            {
                Nombre = rolDto.Nombre,
                FechaAlta = rolDto.FechaAlta,
                FechaBaja = rolDto.FechaBaja,
                Personas = rolDto.Personas
            };

            RolModel? result = await brokerContext.CreateRol(rol);
            return result?.toDto();
        }

        public void Update(int id, string nombre)
        {
            brokerContext.UpdateRol(id, nombre);
        }

        public void Delete(int id)
        {
            brokerContext.DeleteRol(id);
        }
    }
}
