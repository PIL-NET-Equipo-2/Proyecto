using BrokerApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BrokerApi.Dtos
{
    public class NewPersonaDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El apellido es requerido")]

        public string Apellido { get; set; } = null!;

        [Required(ErrorMessage = "El dni es requerido")]
        public string Dni { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El usuario es requerido")]
        public string Usuario { get; set; } = null!;

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Contrasenia { get; set; } = null!;
        public DateTime? FechaAlta { get; set; } = DateTime.Today;
        public DateTime? FechaBaja { get; set; }
        public int? IdLocalidad { get; set; }
        public LocalidadModel? IdLocalidadNavigation { get; set; }
        public List<RolModel>? Roles { get; set; }
        public List<CuentaModel>? Cuentas { get; set; }
    }
}



