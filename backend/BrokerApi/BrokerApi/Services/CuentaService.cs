using BrokerApi.Dtos;
using BrokerApi.Models;
using BrokerApi.Repositories;

namespace BrokerApi.Services
{
    public class CuentaService
    {
        private readonly BrokerContext brokerContext;
        public CuentaService(BrokerContext brokerContext)
        {
            this.brokerContext = brokerContext;
        }

        public async Task<List<CuentaDto>> GetAll()
        {
            return brokerContext.GetAllCuenta().Result.Select(x => x.toDto()).ToList();
        }
        public async Task<CuentaDto?> Get(int id)
        {
            CuentaModel? cuenta = await brokerContext.GetCuenta(id);
            return cuenta?.toDto();
        }

        public async Task<CuentaDto?> Create(NewCuentaDto personaDto)
        {
            CuentaModel cuenta = new CuentaModel
            {
                Cbu = personaDto.Cbu,
                Saldo = personaDto.Saldo,
                EstaHabilitada = personaDto.EstaHabilitada,
                FechaAlta = personaDto.FechaAlta,
                FechaBaja = personaDto.FechaBaja,
                IdPersona = personaDto.IdPersona,
                Compras = personaDto.Compras
            };

            CuentaModel? result = await brokerContext.CreateCuenta(cuenta);
            return result?.toDto();
        }

        public void Update(int id, decimal saldo)
        {
            brokerContext.UpdateCuenta(id, saldo);
        }        
        public void Delete(int id)
        {
            brokerContext.DeleteCuenta(id);
        }        
    }
}
