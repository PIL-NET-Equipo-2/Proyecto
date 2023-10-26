using BrokerApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace BrokerApi.Repositories
{
    public class BrokerContext : DbContext
    {
        public BrokerContext(DbContextOptions<BrokerContext> options) : base(options)
        {
        }

        public DbSet<RolModel> Rol { get; set; }

        public DbSet<PersonaModel> Persona { get; set; }

        public DbSet<LocalidadModel> Localidad { get; set; }

        public DbSet<CuentaModel> Cuenta { get; set; }

        public DbSet<CompraModel> Compra { get; set; }

        public DbSet<AccionModel> Accion { get; set; }



        //************ L O C A L I D A D *************
        public async Task<List<LocalidadModel>> GetAll()
        {
            return await Localidad.ToListAsync();
        }
        public async Task<LocalidadModel?> Get(int id)
        {
            LocalidadModel? localidad = await Localidad.FirstOrDefaultAsync(p => p.IdLocalidad == id);
            return localidad;
        }
        public async Task<LocalidadModel?> Create(LocalidadModel localidad)
        {
            EntityEntry<LocalidadModel> response = await Localidad.AddAsync(localidad);
            await SaveChangesAsync();
            return await Get(response.Entity.IdLocalidad);
        }
        public void Update(int id, string nombre)
        {
            LocalidadModel? localidad = Localidad.FirstOrDefault(x => x.IdLocalidad == id);
            if (localidad != null)
            {
                localidad.Nombre = nombre;
                SaveChanges();
            }
        }
        public void Delete(int id)
        {
            LocalidadModel? localidad = Localidad.FirstOrDefault(x => x.IdLocalidad == id);
            if (localidad != null)
            {
                Localidad.Remove(localidad);
                SaveChanges();
            }
        }



        //*********** R O L ***********
        public async Task<List<RolModel>> GetAllRol()
        {
            return await Rol.ToListAsync();
        }
        public async Task<RolModel?> GetRol(int id)
        {
            RolModel? rol = await Rol.FirstOrDefaultAsync(p => p.IdRol == id);
            return rol;
        }
        public async Task<RolModel?> CreateRol(RolModel rol)
        {
            EntityEntry<RolModel> response = await Rol.AddAsync(rol);
            await SaveChangesAsync();
            return await GetRol(response.Entity.IdRol);
        }
        public void UpdateRol(int id, string nombre)
        {
            RolModel? rol = Rol.FirstOrDefault(x => x.IdRol == id);
            if (rol != null)
            {
                rol.Nombre = nombre;
                SaveChanges();
            }
        }
        public void DeleteRol(int id)
        {
            RolModel? rol = Rol.FirstOrDefault(x => x.IdRol == id);
            if (rol != null)
            {
                Rol.Remove(rol);
                SaveChanges();
            }
        }



        //*********** P E R S O N A ***********
        public async Task<List<PersonaModel>> GetAllPersona()
        {
            return await Persona.ToListAsync();
        }
        public async Task<PersonaModel?> GetPersona(int id)
        {
            PersonaModel? persona = await Persona.FirstOrDefaultAsync(p => p.IdPersona == id);
            return persona;
        }
        public async Task<PersonaModel?> CreatePersona(PersonaModel persona)
        {
            EntityEntry<PersonaModel> response = await Persona.AddAsync(persona);
            await SaveChangesAsync();
            return await GetPersona(response.Entity.IdPersona);
        }

        public void UpdatePersona(int id, string usuario, string contrasenia)
        {
            PersonaModel? persona = Persona.FirstOrDefault(x => x.IdPersona == id);
            if (persona != null)
            {
                persona.Usuario = usuario;
                persona.Contrasenia = contrasenia;
                SaveChanges();
            }
        }
        public void DeletePersona(int id)
        {
            PersonaModel? persona = Persona.FirstOrDefault(x => x.IdPersona == id);
            if (persona != null)
            {
                Persona.Remove(persona);
                SaveChanges();
            }
        }

        public async Task<PersonaModel?> LoguinPersona(string usuario, string contrasenia)
        {
            PersonaModel? persona = await Persona.FirstOrDefaultAsync(p => p.Usuario == usuario);
                          persona = await Persona.FirstOrDefaultAsync(p => p.Contrasenia == contrasenia);
            return persona;
        }




        //*********** C U E N T A ***********
        public async Task<List<CuentaModel>> GetAllCuenta()
        {
            return await Cuenta.ToListAsync();
        }
        public async Task<CuentaModel?> GetCuenta(int id)
        {
            CuentaModel? cuenta = await Cuenta.FirstOrDefaultAsync(p => p.IdCuenta == id);
            return cuenta;
        }
        public async Task<CuentaModel?> CreateCuenta(CuentaModel cuenta)
        {
            EntityEntry<CuentaModel> response = await Cuenta.AddAsync(cuenta);
            await SaveChangesAsync();
            return await GetCuenta(response.Entity.IdCuenta);
        }
        public void UpdateCuenta(int id, decimal saldo)
        {
            CuentaModel? cuenta = Cuenta.FirstOrDefault(x => x.IdCuenta == id);
            if (cuenta != null)
            {
                cuenta.Saldo = saldo;
                SaveChanges();
            }
        }        
        public void DeleteCuenta(int id)
        {
            CuentaModel? cuenta = Cuenta.FirstOrDefault(x => x.IdCuenta == id);
            if (cuenta != null)
            {
                Cuenta.Remove(cuenta);
                SaveChanges();
            }
        }




        //*********** C O M P R A ***********
        public async Task<List<CompraModel>> GetAllCompra()
        {
            return await Compra.ToListAsync();
        }
        public async Task<CompraModel?> GetCompra(int id)
        {
            CompraModel? compra = await Compra.FirstOrDefaultAsync(p => p.IdCompra == id);
            return compra;
        }
        public async Task<CompraModel?> CreateCompra(CompraModel compra)
        {
            EntityEntry<CompraModel> response = await Compra.AddAsync(compra);
            
            CuentaModel? cuenta = Cuenta.FirstOrDefault(x => x.IdCuenta == compra.IdCuenta);
            if (cuenta != null)
            {
                cuenta.Saldo = ((decimal)cuenta.Saldo) - (decimal)compra.Total;                
            }

            await SaveChangesAsync();
            return await GetCompra(response.Entity.IdCompra);
        }
        public void UpdateCompra(int id, int cantidad, decimal total)
        {
            CompraModel? compra = Compra.FirstOrDefault(x => x.IdCompra == id);
            if (compra != null)
            {
                compra.Cantidad = cantidad;
                compra.Total = total;
                SaveChanges();
            }
        }
        public void DeleteCompra(int id)
        {
            CompraModel? compra = Compra.FirstOrDefault(x => x.IdCompra == id);
            if (compra != null)
            {
                Compra.Remove(compra);
                SaveChanges();
            }
        }

        
        public async Task<List<CompraModel>> HistorialCompra(int idCuenta)
        {
            return await Compra.Where(p => p.IdCuenta == idCuenta).ToListAsync();            
        }
    }
}
