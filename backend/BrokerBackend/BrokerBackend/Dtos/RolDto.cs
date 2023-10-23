using BrokerBackend.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokerBackend.Dtos
{
    public class RolDto
    {
        public int IdRol { get; set; }
        public string Name { get; set; } = null!;
    }
}
