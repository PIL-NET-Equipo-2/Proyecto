using BrokerBackend.Dtos;
using BrokerBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrokerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly PurchasesService purchasesService;
        public PurchasesController(PurchasesService purchasesService)
        {
            this.purchasesService = purchasesService;
        }

        /// <summary>
        /// Permite obtener todas las compras registradas en el sistema
        /// </summary>
        /// <response code = "200">Se obtuvieron todas las compras</response>
        /// <response code = "404">No se encontraron compras</response>
        /// <remarks>
        /// 
        /// Ejemplo
        ///     GET /api/Purchases
        /// 
        /// </remarks>
        /// <returns>Listado de todas las compras</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<PurchasesDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this.purchasesService.GetAll());
        }

        /// <summary>
        /// Permite crear una nueva compra
        /// </summary>
        /// <param name="purchases">Compra a crear</param>
        /// <response code = "200">Se creo la compra</response>
        /// <response code = "400">No se pudo crear la compra</response>
        /// <remarks>
        /// 
        /// Ejemplo:
        ///     POST /api/Purchases
        ///     
        ///     {
        ///         "quantity": 300,
        ///         "total": 2000,
        ///         "idPerson": 3,
        ///         "idStock": 5
        ///     }
        /// 
        /// </remarks>
        /// <returns>La compra creada y agregada a la BD</returns>
        [HttpPost]
        [ProducesResponseType(typeof(PurchasesDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult?> Create(NewPurchasesDto purchases)
        {
            return Ok(await purchasesService.Create(purchases));
        }

        /// <summary>
        /// Permite actualizar una compra
        /// </summary>
        /// <param name="id">ID de la compra a actualizar</param>
        /// <param name="cantidad">Cantidad de acciones a modificar</param>
        /// <param name="total">Valor total de la compra</param>
        /// <response code = "200">Se actualizo la compra</response>
        /// <response code = "404">No se encontro la compra</response>
        /// <response code = "400">No se pudo actualizar la compra</response>
        /// <remarks>
        /// 
        /// Ejemplo:
        ///     PUT /api/Purchases/1
        /// 
        /// </remarks>
        /// <returns>La compra actualizada</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PurchasesDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult?> Update(int id, int cantidad, decimal total)
        {
            this.purchasesService.Update(id, cantidad, total);
            return Ok();
        }

        /// <summary>
        /// Permite eliminar una compra
        /// </summary>
        /// <param name="id">ID de la compra a eliminar</param>
        /// <response code = "200">Se elimino la compra</response>
        /// <response code = "404">No se encontro la compra</response>
        /// <remarks>
        /// 
        /// Ejemplo:
        ///     DELETE /api/Purchases/1
        /// 
        /// </remarks>
        /// <returns>El registro eliminado</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult?> Delete(int id)
        {
            this.purchasesService.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Permite obtener el historial de compras de una cuenta
        /// </summary>
        /// <param name="idCuenta">ID de la cuenta del cual queres su historial</param>
        /// <response code = "200">Se obtuvo el historial de compras</response>
        /// <response code = "404">No se encontro el historial de compras</response>
        /// <remarks>
        /// 
        /// Ejemplo:
        ///     GET /api/Purchases/History/1
        /// 
        /// </remarks>
        /// <returns>Listado de compras asociadas a una cuenta</returns>
        [HttpGet("{idCuenta}")]
        [ProducesResponseType(typeof(List<PurchasesDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> History(int idCuenta)
        {
            return Ok(await this.purchasesService.History(idCuenta));
        }

    }
}
