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
    public class CuentaController : ControllerBase
    {
        private readonly CuentaService cuentaService;
        public CuentaController(CuentaService cuentaService)
        {
            this.cuentaService = cuentaService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this.cuentaService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult?> Get(int id)
        {
            CuentaDto? cuenta = await cuentaService.Get(id);
            return cuenta != null ? Ok(cuenta) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult?> Create(NewCuentaDto cuenta)
        {
            return Ok(await cuentaService.Create(cuenta));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult?> Update(int id, decimal saldo)
        {
            this.cuentaService.Update(id, saldo);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult?> Delete(int id)
        {
            this.cuentaService.Delete(id);
            return Ok();
        }
    }
}
