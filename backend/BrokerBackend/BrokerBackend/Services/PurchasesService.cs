﻿using BrokerBackend.Dtos;
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
            return brokerContext.GetAllPurchases().Result.Select(x => x.toDto()).ToList();
        }
        public async Task<PurchasesDto?> GetById(int id)
        {
            PurchasesModel? compra = await brokerContext.GetPurchase(id);
            return compra?.ToDto();
        }

        public async Task<PurchasesDto?> Create(NewPurchasesDto purchasesDto)
        {
            PurchasesModel purchases = new PurchasesModel
            {
                IdPurchase = purchasesDto.IdPurchase,
                PurchaseDate = purchasesDto.PurchaseDate,
                Quantity = purchasesDto.Quantity,
                Total = purchasesDto.Total,
                IdPerson = purchasesDto.IdPerson,
                IdStock = purchasesDto.IdStock
            };

            PurchasesModel? result = await brokerContext.CreatePurchases(Purchases);
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
            return brokerContext.HistoryPurchases(idCuenta).Result.Select(x => x.toDto()).ToList();
        }
    }
}
