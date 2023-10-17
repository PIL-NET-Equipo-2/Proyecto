namespace BrokerApi.Dtos
{
    public class CompraDto
    {
        public int IdCompra { get; set; }
        public DateTime? Fecha { get; set; } = DateTime.Today;
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public int? IdCuenta { get; set; }
        public int? IdAccion { get; set; }
    }
}
