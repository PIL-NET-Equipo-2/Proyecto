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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this.purchasesService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult?> Create(NewPurchasesDto purchases)
        {
            return Ok(await purchasesService.Create(purchases));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult?> Update(int id, int cantidad, decimal total)
        {
            this.purchasesService.Update(id, cantidad, total);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult?> Delete(int id)
        {
            this.purchasesService.Delete(id);
            return Ok();
        }

        [HttpGet("{idCuenta}")]
        public async Task<IActionResult> History(int idCuenta)
        {
            return Ok(await this.purchasesService.History(idCuenta));
        }

    }
}
