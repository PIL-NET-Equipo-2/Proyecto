using BrokerApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BrokerApi.Dtos
{
    public class NewCompraDto
    {
        public DateTime? Fecha { get; set; } = DateTime.Today;
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int? IdCuenta { get; set; }
        public int? IdAccion { get; set; }
        public AccionModel? IdAccionNavigation { get; set; }
        public CuentaModel? IdCuentaNavigation { get; set; }
    }
}


