using BrokerBackend.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Column(TypeName = "varchar(40)")]
        public string Mail { get; set; } = null!;

        [Column(TypeName = "varchar(15)")]
        public string Password { get; set; } = null!;

        [Column(TypeName = "varchar(15)")]
        public string State { get; set; } = null!;

        [Column(TypeName = "varchar(15)")]
        public string City { get; set; } = null!;

        [Column(TypeName = "varchar(15)")]
        public string Address { get; set; } = null!;

        [Column(TypeName = "decimal(11,2)")]
        public decimal AccountMoney { get; set; } = 1000000;

        public List<PurchasesModel>? Purchases { get; set; }
        public int IdRol { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ActiveDate { get; set; } = DateTime.Today;

        [Column(TypeName = "datetime")]
        public DateTime? InactiveDate { get; set; }

        //[ForeignKey("IdRol")]
        //public RolModel? IdRolNavigation { get; set; }

        public PersonDto ToDto()
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
                Address = Address,
                AccountMoney = AccountMoney,
                ActiveDate = ActiveDate,
                InactiveDate = InactiveDate,
                IdRol = IdRol
            };
        }

    }
}
