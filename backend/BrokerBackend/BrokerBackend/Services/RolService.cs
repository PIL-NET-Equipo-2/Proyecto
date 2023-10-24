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

        /// <summary>
        /// Metodo que trae un rol por su ID
        /// </summary>
        /// <param name="id">ID del rol a obtener</param>
        /// <returns></returns>
        public async Task<RolDto?> GetById(int id)
        {
            RolModel? rol = await brokerContext.GetRolById(id);
            return rol?.ToDto();
        }

        /// <summary>
        /// Metodo que permite crear un nuevo rol
        /// </summary>
        /// <param name="rolDto">Rol a crear</param>
        /// <returns>El rol nuevo</returns>
        public async Task<RolDto?> Create(NewRolDto rolDto)
        {
            RolModel rol = new RolModel
            {
                Name = rolDto.Name
            };

            RolModel? result = await brokerContext.CreateRol(rol);
            return result?.ToDto();
        }
    }
}
