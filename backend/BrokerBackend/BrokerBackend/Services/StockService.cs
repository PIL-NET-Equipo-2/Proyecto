using BrokerBackend.Dtos;
using BrokerBackend.Models;
using BrokerBackend.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BrokerBackend.Services
{
    public class StockService
    {
        private readonly BrokerContext brokerContext;
        public StockService(BrokerContext brokerContext)
        {
            this.brokerContext = brokerContext;
        }

        public async Task<List<StockDto>> GetAll()
        {
            return brokerContext.GetAllStock().Result.Select(x => x.toDto()).ToList();
        }
        public async Task<StockDto?> GetById(int id)
        {
            StockModel? stock = await brokerContext.GetStockById(id);
            return stock?.ToDto();
        }

        public async Task<StockDto?> Create(NewStockDto stockDto)
        {
            PersonModel stock = new StockModel
            {
                IdStock = stockDto.IdStock,
                Symbol = stockDto.Symbol,
                Company = stockDto.Company,
                Logo = stockDto.Logo,
                Price = stockDto.Price,
                ActiveDate = stockDto.ActiveDate,
                InactiveDate = stockDto.InactiveDate,
            };

            StockModel? result = await brokerContext.CreateStock(stock);
            return result?.ToDto();
        }

    }
}
