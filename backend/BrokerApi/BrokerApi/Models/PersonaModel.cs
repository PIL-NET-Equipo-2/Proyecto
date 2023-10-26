using BrokerApi.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokerApi.Models
{
    [Table("Personas")]
    public class PersonaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPersona { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string Nombre { get; set; } = null!;

        [Column(TypeName = "varchar(15)")]
        public string Apellido { get; set; } = null!;

        [Column(TypeName = "varchar(15)")]
        public string Dni { get; set; } = null!;

        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string Usuario { get; set; } = null!;

        [Column(TypeName = "varchar(15)")]
        public string Contrasenia { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime? FechaAlta { get; set; } = DateTime.Today;

        [Column(TypeName = "datetime")]
        public DateTime? FechaBaja { get; set; }

        public int? IdLocalidad { get; set; }

        [ForeignKey("IdLocalidad")]
        public LocalidadModel? IdLocalidadNavigation { get; set; }

        public List<RolModel>? Roles { get; set; }
        public List<CuentaModel>? Cuentas { get; set; }


        public PersonaDto toDto()
        {
            return new PersonaDto { IdPersona= IdPersona, Nombre = Nombre, Apellido= Apellido, 
                Dni = Dni, FechaNacimiento = FechaNacimiento, Usuario = Usuario, 
                Contrasenia = Contrasenia, IdLocalidad = IdLocalidad };
        }
    }
}
