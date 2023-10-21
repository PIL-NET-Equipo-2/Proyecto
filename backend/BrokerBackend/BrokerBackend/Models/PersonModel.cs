using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BrokerBackend.Dtos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BrokerBackend.Models
{
    [Table("Persons")]
    public class PersonModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPerson { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string Name { get; set; } = null!;

        [Column(TypeName = "varchar(15)")]
        public string Lastname { get; set; } = null!;

        [Column(TypeName = "varchar(15)")]
        public string Dni { get; set; } = null!;

        [Column(TypeName = "varchar(15)")]
        public string Gender { get; set; } = null!;

        [Column(TypeName = "varchar(15)")]
        public string Mail { get; set; } = null!;

        [Column(TypeName = "varchar(15)")]
        public string Password { get; set; } = null!;

        [Column(TypeName = "varchar(15)")]
        public string State { get; set; } = null!;

        [Column(TypeName = "varchar(15)")]
        public string City { get; set; } = null!;

        [Column(TypeName = "varchar(15)")]
        public string Adress { get; set; } = null!;

        [Column(TypeName = "decimal(11,2)")]
        public decimal AccountMoney { get; set; }

        public List<PurchasesModel>? Purchases { get; set; }
        public List<RolModel>? Rol { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ActiveDate { get; set; } = DateTime.Today;

        [Column(TypeName = "datetime")]
        public DateTime? InactiveDate { get; set; }

        public PersonDto toDto()
        {
            return new PersonDto
            {
                IdPerson = IdPerson,
                Name = Name,
                Lastname = Lastname,
                Dni = Dni,
                Gender = Gender,
                Mail = Mail,
                Password = Password,
                State = State,
                City = City,
                Adress = Adress,
                AccountMoney = AccountMoney,
                ActiveDate = ActiveDate,
                InactiveDate = InactiveDate
            };
        }

    }
}
