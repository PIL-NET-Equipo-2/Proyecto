using BrokerApi.Dtos;
using BrokerApi.Models;
using BrokerApi.Repositories;

namespace BrokerApi.Services
{
    public class CompraService
    {
        private readonly BrokerContext brokerContext;
        public CompraService(BrokerContext brokerContext)
        {
            this.brokerContext = brokerContext;
        }

        public async Task<List<CompraDto>> GetAll()
        {
            return brokerContext.GetAllCompra().Result.Select(x => x.toDto()).ToList();
        }
        public async Task<CompraDto?> Get(int id)
        {
            CompraModel? compra = await brokerContext.GetCompra(id);
            return compra?.toDto();
        }

        public async Task<CompraDto?> Create(NewCompraDto compraDto)
        {
            CompraModel compra = new CompraModel
            {
                Fecha = compraDto.Fecha,
                Cantidad = compraDto.Cantidad,
                Total = compraDto.Total,
                FechaBaja = compraDto.FechaBaja,
                IdCuenta = compraDto.IdCuenta,
                IdAccion = compraDto.IdAccion
            };

            CompraModel? result = await brokerContext.CreateCompra(compra);
            return result?.toDto();
        }

        public void Update(int id, int cantidad, decimal total)
        {
            brokerContext.UpdateCompra(id, cantidad, total);
        }

        public void Delete(int id)
        {
            brokerContext.DeleteCompra(id);
        }

        public async Task<List<CompraDto>> Historial(int idCuenta)
        {
            return brokerContext.HistorialCompra(idCuenta).Result.Select(x => x.toDto()).ToList();
        }
    }
}
