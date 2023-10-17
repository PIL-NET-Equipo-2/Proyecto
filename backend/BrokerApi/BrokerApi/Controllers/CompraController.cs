using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BrokerApi.Models;
using BrokerApi.Repositories;
using BrokerApi.Services;
using BrokerApi.Dtos;

namespace BrokerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly CompraService compraService;
        public CompraController(CompraService compraService)
        {
            this.compraService = compraService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this.compraService.GetAll());
        }

        //LO COMENTO PQ HAY 2 GET CON UN ATRIBUTO Y ESO DA ERROR
        //[HttpGet("{id}")] 
        //public async Task<IActionResult?> Get(int id)
        //{
        //    CompraDto? compra = await compraService.Get(id);
        //    return compra != null ? Ok(compra) : NotFound();
        //}

        [HttpPost]
        public async Task<IActionResult?> Create(NewCompraDto compra)
        {
            return Ok(await compraService.Create(compra));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult?> Update(int id, int cantidad, decimal total)
        {
            this.compraService.Update(id, cantidad, total);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult?> Delete(int id)
        {
            this.compraService.Delete(id);
            return Ok();
        }

        [HttpGet("{idCuenta}")]
        public async Task<IActionResult> Historial(int idCuenta)
        {
            return Ok(await this.compraService.Historial(idCuenta));
        }


    }
}
