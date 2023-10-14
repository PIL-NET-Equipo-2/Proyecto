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
    }
}
