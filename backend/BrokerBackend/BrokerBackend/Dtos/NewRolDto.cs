using BrokerBackend.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokerBackend.Dtos
{
    public class NewRolDto
    {
        public string Name { get; set; } = null!;
        public List<PersonModel>? Person { get; set; }
    }
}
