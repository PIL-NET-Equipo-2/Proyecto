using BrokerBackend.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokerBackend.Models
{
    [Table("Rol")]
    public class RolModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRol { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string Name { get; set; } = null!;

        public List<PersonModel>? Person { get; set; }
        public RolDto ToDto()
        {
            return new RolDto
            {
                IdRol = IdRol,
                Name = Name,
                Person = Person
            };
        }
    }
}
