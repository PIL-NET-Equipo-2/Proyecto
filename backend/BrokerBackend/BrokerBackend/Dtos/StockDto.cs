using BrokerBackend.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokerBackend.Dtos
{
    public class StockDto
    {
        public string Symbol { get; set; } = null!;
        public string Company { get; set; } = null!;
        public string Logo { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime? ActiveDate { get; set; } = DateTime.Today;
        public DateTime? InactiveDate { get; set; }
    }
}
