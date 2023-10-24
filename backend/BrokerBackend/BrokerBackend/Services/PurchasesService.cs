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

        /// <summary>
        /// Metodo que trae todas las compras registradas en el sistema
        /// </summary>
        /// <returns>Listado de compras</returns>
        public async Task<List<PurchasesDto>> GetAll()
        {
            return brokerContext.GetAllPurchases().Result.Select(x => x.ToDto()).ToList();
        }

        /// <summary>
        /// Metodo que trae una compra de acuerdo a su ID
        /// </summary>
        /// <param name="id">ID de la compra a traer</param>
        /// <returns>La compra pedida por su ID</returns>
        public async Task<PurchasesDto?> GetById(int id)
        {
            PurchasesModel? purchase = await brokerContext.GetPurchaseById(id);
            return purchase?.ToDto();
        }

        /// <summary>
        /// Metodo que crea una nueva compra
        /// </summary>
        /// <param name="purchasesDto">Compra a crear</param>
        /// <returns>La compra creada</returns>
        public async Task<PurchasesDto?> Create(NewPurchasesDto purchasesDto)
        {
            PurchasesModel purchases = new PurchasesModel
            {
                PurchaseDate = purchasesDto.PurchaseDate,
                Quantity = purchasesDto.Quantity,
                Total = purchasesDto.Total,
                IdPerson = purchasesDto.IdPerson,
            };

            PurchasesModel? result = await brokerContext.CreatePurchases(purchases);
            return result?.ToDto();
        }

        /// <summary>
        /// Metodo que actualiza una compra
        /// </summary>
        /// <param name="id">ID de la compra</param>
        /// <param name="cantidad">Nueva cantidad a modificar</param>
        /// <param name="total">Nuevo total a modificar</param>
        public void Update(int id, int cantidad, decimal total)
        {
            brokerContext.UpdatePurchase(id, cantidad, total);
        }

        /// <summary>
        /// Metodo que elimina una compra
        /// </summary>
        /// <param name="id">ID de compra a eliminar</param>
        public void Delete(int id)
        {
            brokerContext.DeletePurchase(id);
        }

        /// <summary>
        /// Metodo que permite obtener el historial de compras de una cuenta
        /// </summary>
        /// <param name="idCuenta">ID de la cuenta</param>
        /// <returns>Listado de compras de la cuenta</returns>
        public async Task<List<PurchasesDto>> History(int idCuenta)
        {
            return brokerContext.HistoryPurchases(idCuenta).Result.Select(x => x.ToDto()).ToList();
        }
    }
}
