using BrokerApi.Models;

namespace BrokerApi.Dtos
{
    public class CuentaDto
    {
        public int IdCuenta { get; set; }
        public string Cbu { get; set; } = null!;
        public decimal Saldo { get; set; }
        public bool EstaHabilitada { get; set; } = false;        
        public int? IdPersona { get; set; }

        //public DateTime? FechaAlta { get; set; } = DateTime.Today;
        //public DateTime? FechaBaja { get; set; }
        //public PersonaModel? IdPersonaNavigation { get; set; }
        //public List<CompraModel>? Compras { get; set; }
    }
}
