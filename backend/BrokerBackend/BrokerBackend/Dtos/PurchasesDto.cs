using BrokerBackend.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BrokerBackend.Dtos
{
    public class PurchasesDto
    {
        public int IdPurchase { get; set; }
        public DateTime? PurchaseDate { get; set; } = DateTime.Today;
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public int? IdPerson { get; set; }
        public int? IdStock { get; set; }
    }
}
