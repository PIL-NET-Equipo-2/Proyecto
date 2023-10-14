using BrokerApi.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokerApi.Models
{
    [Table("Localidades")]
    public class LocalidadModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLocalidad { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string Nombre { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime? FechaAlta { get; set; } = DateTime.Today;

        [Column(TypeName = "datetime")]
        public DateTime? FechaBaja { get; set; }

        public List<PersonaModel>? Personas { get; set; }

        public LocalidadDto toDto()
        {
            return new LocalidadDto { IdLocalidad = IdLocalidad, Nombre = Nombre };
        }
    }
}
