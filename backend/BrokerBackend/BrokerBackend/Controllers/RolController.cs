using BrokerBackend.Dtos;
using BrokerBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrokerBackend.Controllers
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

        /// <summary>
        /// Permite obtener un rol por su id
        /// </summary>
        /// <param name="id">ID del rol a obtener</param>
        /// <response code = "200">Se obtuvo el rol</response>
        /// <response code = "404">No se encontro el rol</response>
        /// <remarks>
        /// 
        /// Ejemplo:
        ///     GET /api/Rol/1
        /// 
        /// </remarks>
        /// <returns>El rol pedido</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RolDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult?> GetById(int id)
        {
            RolDto? rol = await rolService.GetById(id);
            return rol != null ? Ok(rol) : NotFound();
        }

        /// <summary>
        /// Permite crear un nuevo rol
        /// </summary>
        /// <param name="rol">El nuevo rol a crear</param>
        /// <response code = "200">Se creo el rol</response>
        /// <response code = "400">No se pudo crear el rol</response>
        /// <remarks>
        /// 
        /// Ejemplo:
        ///     POST /api/Rol
        ///     
        ///     {
        ///         "name": "Admin"
        ///     }
        /// 
        /// </remarks>
        /// <returns>El rol sumado a la BD</returns>
        [HttpPost]
        public async Task<IActionResult?> Create(NewRolDto rol)
        {
            return Ok(await rolService.Create(rol));
        }

    }
}

