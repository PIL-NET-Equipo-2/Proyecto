using BrokerApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BrokerApi.Dtos
{
    public class NewCuentaDto
    {
        [Required(ErrorMessage = "El cbu es requerido")]
        public string Cbu { get; set; } = null!;
        public decimal Saldo { get; set; }
        public bool EstaHabilitada { get; set; } = false;
        public DateTime? FechaAlta { get; set; } = DateTime.Today;
        public DateTime? FechaBaja { get; set; }
        public int? IdPersona { get; set; }
        public PersonaModel? IdPersonaNavigation { get; set; }
        public List<CompraModel>? Compras { get; set; }
    }
}


