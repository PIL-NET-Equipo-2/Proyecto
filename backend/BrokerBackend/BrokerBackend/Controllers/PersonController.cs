using BrokerBackend.Dtos;
using BrokerBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrokerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService personService;
        public PersonController(PersonService personService)
        {
            this.personService = personService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this.personService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult?> GetById(int id)
        {
            PersonDto? person = await personService.GetById(id);
            return person != null ? Ok(person) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult?> Create(NewPersonDto person)
        {
            return Ok(await personService.Create(person));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult?> Update(int id, string usuario, string contrasenia)
        {
            this.personService.Update(id, usuario, contrasenia);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult?> Delete(int id)
        {
            this.personService.Delete(id);
            return Ok();
        }

        [HttpPost("{usuario}, {contrasenia}")]
        public async Task<IActionResult?> Login(string usuario, string contrasenia)
        {
            PersonDto? person = await personService.Login(usuario, contrasenia);
            return person != null ? Ok("Bienvenido " + usuario) : NotFound("Usuario o Contraseña Inválida");
        }
    }
}
