using BrokerBackend.Models;

namespace BrokerBackend.Dtos
{
    public class RolDto
    {
        public int IdRol { get; set; }
        public string Name { get; set; } = null!;
        public List<PersonModel>? Person { get; set; }

    }
}
