using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokerApi.Models
{
    [Table("Cuentas")]
    public class CuentaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCuenta { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string Cbu { get; set; } = null!;

        [Column(TypeName = "decimal(11,2)")]
        public decimal Saldo { get; set; }

        public bool EstaHabilitada { get; set; } = false;

        [Column(TypeName = "datetime")]
        public DateTime? FechaAlta { get; set; } = DateTime.Today;

        [Column(TypeName = "datetime")]
        public DateTime? FechaBaja { get; set; }

        public int? IdPersona { get; set; }

        [ForeignKey("IdPersona")]
        public PersonaModel? IdPersonaNavigation { get; set; }

        public List<CompraModel>? Compras { get; set; }
    }
}
