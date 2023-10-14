using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokerApi.Models
{
    [Table("Acciones")]
    public class AccionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAccion { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Simbolo { get; set; } = null!;

        [Column(TypeName = "varchar(15)")]
        public string Empresa { get; set; } = null!;

        [Column(TypeName = "varchar(50)")]
        public string Logo { get; set; } = null!;

        [Column(TypeName = "decimal(11,2)")]
        public decimal Precio { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? FechaAlta { get; set; } = DateTime.Today;

        [Column(TypeName = "datetime")]
        public DateTime? FechaBaja { get; set; }

        public List<CompraModel>? Compras { get; set; }
    }
}
