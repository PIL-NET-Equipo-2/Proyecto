namespace BrokerBackend.Dtos
{
    public class PersonDto
    {
        public int IdPerson { get; set; }
        public string Name { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Dni { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string State { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int IdRol { get; set; }
        public decimal AccountMoney { get; set; }
        public DateTime? ActiveDate { get; set; } = DateTime.Today;
        public DateTime? InactiveDate { get; set; }
    }
}
