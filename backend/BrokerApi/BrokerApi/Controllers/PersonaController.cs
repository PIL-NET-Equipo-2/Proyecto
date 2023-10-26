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
    public class PersonaController : ControllerBase
    {
        private readonly PersonaService personaService;
        public PersonaController(PersonaService personaService)
        {
            this.personaService = personaService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this.personaService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult?> Get(int id)
        {
            PersonaDto? persona = await personaService.Get(id);
            return persona != null ? Ok(persona) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult?> Create(NewPersonaDto persona)
        {
            return Ok(await personaService.Create(persona));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult?> Update(int id, string usuario, string contrasenia)
        {
            this.personaService.Update(id, usuario, contrasenia);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult?> Delete(int id)
        {
            this.personaService.Delete(id);
            return Ok();
        }

        [HttpGet("{usuario}, {contrasenia}")]
        public async Task<IActionResult?> Loguin(string usuario, string contrasenia)
        {
            PersonaDto? persona = await personaService.Loguin(usuario, contrasenia);
            return persona != null ? Ok("Bienvenido "+usuario) : NotFound("Usuario o Contraseña Inválida");
        }
    }
}
