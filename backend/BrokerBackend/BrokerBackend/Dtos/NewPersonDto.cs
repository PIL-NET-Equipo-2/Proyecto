using BrokerBackend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokerBackend.Dtos
{
    public class NewPersonDto
    {

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "El apellido es requerido")]
        public string Lastname { get; set; } = null!;

        [Required(ErrorMessage = "El numero de documento es requerido")]
        public string Dni { get; set; } = null!;

        [Required(ErrorMessage = "El genero es requerido")]
        public string Gender { get; set; } = null!;

        [Required(ErrorMessage = "El mail es requerido")]
        public string Mail { get; set; } = null!;

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "La provincia es requerida")]
        public string State { get; set; } = null!;

        [Required(ErrorMessage = "La Ciudad es requerida")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "La direccion es requerida")]
        public string Adress { get; set; } = null!;

        public decimal AccountMoney { get; set; }

        public List<PurchasesModel>? Purchases { get; set; }

        public List<RolModel>? Rol { get; set; }

        public DateTime? ActiveDate { get; set; } = DateTime.Today;

        public DateTime? InactiveDate { get; set; }
    }
}
