using BrokerBackend.Dtos;
using BrokerBackend.Models;
using BrokerBackend.Repositories;

namespace BrokerBackend.Services
{
    public class RolService
    {
        private readonly BrokerContext brokerContext;
        public RolService(BrokerContext brokerContext)
        {
            this.brokerContext = brokerContext;
        }

        public async Task<RolDto?> GetById(int id)
        {
            RolModel? rol = await brokerContext.GetRol(id);
            return rol?.ToDto();
        }

        public async Task<RolDto?> Create(NewRolDto rolDto)
        {
            RolModel rol = new RolModel
            {
                IdRol = rolDto.IdRol,
                Name = rolDto.Name
            };

            RolModel? result = await brokerContext.CreateRol(rol);
            return result?.ToDto();
        }
    }
}
