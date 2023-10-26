using BrokerBackend.Dtos;
using BrokerBackend.Services;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("{id}")]
        public async Task<IActionResult?> GetById(int id)
        {
            RolDto? rol = await rolService.GetById(id);
            return rol != null ? Ok(rol) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult?> Create(NewRolDto rol)
        {
            return Ok(await rolService.Create(rol));
        }

        }
    }

