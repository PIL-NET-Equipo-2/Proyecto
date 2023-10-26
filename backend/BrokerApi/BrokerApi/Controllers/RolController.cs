using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BrokerApi.Models;
using BrokerApi.Repositories;
using BrokerApi.Services;
using BrokerApi.Dtos;

namespace BrokerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly RolService rolService;
        public RolController(RolService rolService)
        {
            this.rolService = rolService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this.rolService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult?> Get(int id)
        {
            RolDto? rol = await rolService.Get(id);
            return rol != null ? Ok(rol) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult?> Create(NewRolDto rol)
        {
            return Ok(await rolService.Create(rol));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult?> Update(int id, string nombre)
        {
            this.rolService.Update(id, nombre);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult?> Delete(int id)
        {
            this.rolService.Delete(id);
            return Ok();
        }
    }
}
