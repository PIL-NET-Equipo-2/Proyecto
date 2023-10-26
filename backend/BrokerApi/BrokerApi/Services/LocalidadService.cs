using BrokerApi.Dtos;
using BrokerApi.Models;
using BrokerApi.Repositories;

namespace BrokerApi.Services
{
    public class LocalidadService
    {
        private readonly BrokerContext brokerContext;
        public LocalidadService(BrokerContext brokerContext)
        {
            this.brokerContext = brokerContext;
        }

        public async Task<List<LocalidadDto>> GetAll()
        {
            return brokerContext.GetAll().Result.Select(x => x.toDto()).ToList();
        }
        public async Task<LocalidadDto?> Get(int id)
        {
            LocalidadModel? localidad = await brokerContext.Get(id);
            return localidad?.toDto();
        }

        public async Task<LocalidadDto?> Create(NewLocalidadDto localidadDto)
        {
            LocalidadModel localidad = new LocalidadModel
            {
                Nombre = localidadDto.Nombre,
                FechaAlta = localidadDto.FechaAlta,
                FechaBaja = localidadDto.FechaBaja,
                Personas = localidadDto.Personas
            };

            LocalidadModel? result = await brokerContext.Create(localidad);
            return result?.toDto();
        }

        public void Update(int id, string nombre)
        {
            brokerContext.Update(id, nombre);
        }

        public void Delete(int id)
        {
            brokerContext.Delete(id);
        }

    }
}


