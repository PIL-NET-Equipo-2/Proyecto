using BrokerApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BrokerApi.Dtos
{
    public class NewRolDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; } = null!;

        public DateTime? FechaAlta { get; set; } = DateTime.Today;

        public DateTime? FechaBaja { get; set; }

        public List<PersonaModel>? Personas { get; set; }
    }
}
