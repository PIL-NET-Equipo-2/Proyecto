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

        /// <summary>
        /// Permite obtener todas las personas registradas en el sistema
        /// </summary>
        /// <response code = "200">Se obtuvieron todas las personas</response>
        /// <response code = "404">No se encontraron personas</response>
        /// <remarks>
        /// 
        /// Ejemplo 
        ///     GET /api/Person
        ///     
        /// </remarks>
        /// <returns>Listado de las personas registradas</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<PersonDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this.personService.GetAll());
        }

        /// <summary>
        /// Permite obtener una persona por su id
        /// </summary>
        /// <param name="id">ID de la persona a obtener</param>
        /// <response code = "200">Se obtuvo la persona</response>
        /// <response code = "404">No se encontro la persona</response>
        /// <remarks>
        /// 
        /// Ejemplo:
        ///     GET /api/Person/1
        /// 
        /// </remarks>
        /// <returns>Informacion sobre la persona especificada</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PersonDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult?> GetById(int id)
        {
            PersonDto? person = await personService.GetById(id);
            return person != null ? Ok(person) : NotFound();
        }

        /// <summary>
        /// Permite crear una nueva persona
        /// </summary>
        /// <param name="person">El DTO de la persona a agregar</param>
        /// <response code = "200">Se creo la persona</response>
        /// <response code = "400">No se pudo crear la persona</response>
        /// <remarks>
        /// 
        /// Ejemplo
        ///     POST /api/Person
        /// 
        /// </remarks>
        /// <returns>La persona subida a la BD</returns>
        [HttpPost]
        [ProducesResponseType(typeof(PersonDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult?> Create(NewPersonDto person)
        {
            return Ok(await personService.Create(person));
        }

        /// <summary>
        /// Permite modificar una persona
        /// </summary>
        /// <param name="id">ID de la persona a modificar</param>
        /// <param name="usuario">Usuario de la persona a modificar</param>
        /// <param name="contrasenia">Contraseña de la persona a modificar</param>
        /// <response code = "200">Se modifico la persona</response>
        /// <response code = "400">No se pudo modificar la persona</response>
        /// <response code = "404">No se encontro la persona</response>
        /// <remarks>
        /// 
        /// Ejemplo
        ///     PUT /api/Person/1
        /// 
        /// </remarks>
        /// <returns>La persona modificada</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PersonDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult?> Update(int id, string usuario, string contrasenia)
        {
            this.personService.Update(id, usuario, contrasenia);
            return Ok();
        }

        /// <summary>
        /// Permite eliminar una persona
        /// </summary>
        /// <param name="id">ID de la persona a eliminar</param>
        /// <response code = "200">Se elimino la persona</response>
        /// <response code = "404">No se encontro la persona</response>
        /// <remarks>
        /// 
        /// Ejemplo
        ///     DELETE /api/Person/1
        /// 
        /// </remarks>
        /// <returns>El registro eliminado</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PersonDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult?> Delete(int id)
        {
            this.personService.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Permite loguearse en el sistema
        /// </summary>
        /// <param name="usuario">Usuario a </param>
        /// <param name="contrasenia"></param>
        /// <response code = "200">Se logueo al sistema</response>
        /// <response code = "404">No se pudo loguear al sistema</response>
        /// <remarks>
        /// 
        /// Ejemplo
        ///     GET /api/Person/usuario, contrasenia
        /// 
        /// </remarks>
        /// <returns>Logueo al sistema</returns>
        [HttpGet("{usuario}, {contrasenia}")]
        [ProducesResponseType(typeof(PersonDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult?> Login(string usuario, string contrasenia)
        {
            PersonDto? person = await personService.Login(usuario, contrasenia);
            return person != null ? Ok("Bienvenido " + usuario) : NotFound("Usuario o Contraseña Inválida");
        }
    }
}
