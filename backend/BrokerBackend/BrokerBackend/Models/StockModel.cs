using BrokerBackend.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BrokerBackend.Models
{
    [Table("Stock")]
    public class StockModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStock { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Symbol { get; set; } = null!;

        [Column(TypeName = "varchar(15)")]
        public string Company { get; set; } = null!;

        [Column(TypeName = "varchar(50)")]
        public string Logo { get; set; } = null!;

        [Column(TypeName = "decimal(11,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ActiveDate { get; set; } = DateTime.Today;

        [Column(TypeName = "datetime")]
        public DateTime? InactiveDate { get; set; }

        public List<PurchasesModel>? Purchases { get; set; }

        public StockDto toDto()
        {
            return new StockDto { 
                IdStock = IdStock,
                Symbol = Symbol,
                Company = Company,
                Logo = Logo,
                Price = Price,
                ActiveDate = ActiveDate,
                InactiveDate = InactiveDate,
            };
        }
    }
}
