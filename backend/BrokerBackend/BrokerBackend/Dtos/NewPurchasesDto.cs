namespace BrokerBackend.Dtos
{
    public class NewPurchasesDto
    {
        public DateTime? PurchaseDate { get; set; } = DateTime.Today;

        public int Quantity { get; set; }

        public decimal Total { get; set; }

        public int? IdPerson { get; set; }

        public string? Symbol { get; set; }

    }
}
