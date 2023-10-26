namespace BrokerApi.Dtos
{
    public class PersonaDto
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Dni { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Usuario { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public int? IdLocalidad { get; set; }

        //public DateTime? FechaAlta { get; set; } = DateTime.Today;
        //public DateTime? FechaBaja { get; set; }        
        //public LocalidadModel? IdLocalidadNavigation { get; set; }
        //public List<RolModel>? Roles { get; set; }
        //public List<CuentaModel>? Cuentas { get; set; }
    }
}
