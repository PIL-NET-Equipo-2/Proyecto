using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BrokerBackend.Dtos;

namespace BrokerBackend.Models
{
    [Table("Purchases")]
    public class PurchasesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPurchase { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? PurchaseDate { get; set; } = DateTime.Today;

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(11,2)")]
        public decimal Total { get; set; }

        public int? IdPerson { get; set; }
         
        public int? IdStock { get; set; }

        [ForeignKey("IdStock")]
        public StockModel? IdAccionNavigation { get; set; }

        [ForeignKey("IdPerson")]
        public PersonModel? IdCuentaNavigation { get; set; }

        public PurchasesDto toDto()
        {
            return new PurchasesDto
            {
                IdPurchase = IdPurchase,
                PurchaseDate = PurchaseDate,
                Quantity = Quantity,
                Total = Total,
                IdPerson = IdPerson,
                IdStock = IdStock
            };
        }
    }
}
