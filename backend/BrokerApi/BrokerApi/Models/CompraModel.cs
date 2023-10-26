using BrokerApi.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokerApi.Models
{
    [Table("Compras")]
    public class CompraModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCompra { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? Fecha { get; set; } = DateTime.Today;

        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(11,2)")]
        public decimal Total { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? FechaBaja { get; set; }

        public int? IdCuenta { get; set; }

        public int? IdAccion { get; set; }

        [ForeignKey("IdAccion")]
        public AccionModel? IdAccionNavigation { get; set; }

        [ForeignKey("IdCuenta")]
        public CuentaModel? IdCuentaNavigation { get; set; }


        public CompraDto toDto()
        {
            return new CompraDto { IdCompra = IdCompra, Fecha = Fecha, Cantidad = Cantidad, Total = Total, 
                IdCuenta = IdCuenta, IdAccion = IdAccion };
        }
    }
}
