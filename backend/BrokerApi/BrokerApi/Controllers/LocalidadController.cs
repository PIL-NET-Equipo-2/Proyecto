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
    public class LocalidadController : ControllerBase
    {
        private readonly LocalidadService localidadService;
        public LocalidadController(LocalidadService localidadService)
        {
            this.localidadService = localidadService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this.localidadService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult?> Get(int id)
        {
            LocalidadDto? localidad = await localidadService.Get(id);
            return localidad != null ? Ok(localidad) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult?> Create(NewLocalidadDto localidad)
        {
            return Ok(await localidadService.Create(localidad));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult?> Update(int id, string nombre)
        {
            this.localidadService.Update(id, nombre);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult?> Delete(int id)
        {
            this.localidadService.Delete(id);
            return Ok();
        }
    }
}
