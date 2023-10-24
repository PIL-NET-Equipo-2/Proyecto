using BrokerBackend.Dtos;
using BrokerBackend.Models;
using BrokerBackend.Repositories;

namespace BrokerBackend.Services
{
    public class PurchasesService
    {
        private readonly BrokerContext brokerContext;
        public PurchasesService(BrokerContext brokerContext)
        {
            this.brokerContext = brokerContext;
        }

        public async Task<List<PurchasesDto>> GetAll()
        {
            return brokerContext.GetAllPurchases().Result.Select(x => x.ToDto()).ToList();
        }
        public async Task<PurchasesDto?> GetById(int id)
        {
            PurchasesModel? purchase = await brokerContext.GetPurchaseById(id);
            return purchase?.ToDto();
        }

        public async Task<PurchasesDto?> Create(NewPurchasesDto purchasesDto)
        {
            PurchasesModel purchases = new PurchasesModel
            {
                PurchaseDate = purchasesDto.PurchaseDate,
                Quantity = purchasesDto.Quantity,
                Total = purchasesDto.Total,
                IdPerson = purchasesDto.IdPerson,
                Symbol = purchasesDto.Symbol,
            };

            PurchasesModel? result = await brokerContext.CreatePurchases(purchases);
            return result?.ToDto();
        }

        public void Update(int id, int cantidad, decimal total)
        {
            brokerContext.UpdatePurchase(id, cantidad, total);
        }

        public void Delete(int id)
        {
            brokerContext.DeletePurchase(id);
        }

        public async Task<List<PurchasesDto>> History(int idCuenta)
        {
            return brokerContext.HistoryPurchases(idCuenta).Result.Select(x => x.ToDto()).ToList();
        }
    }
}
