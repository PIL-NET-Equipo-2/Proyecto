using BrokerBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BrokerBackend.Repositories
{
    public class BrokerContext : DbContext
    {
        public BrokerContext(DbContextOptions<BrokerContext> options) : base(options)
        {
        }

        public DbSet<PersonModel> Person { get; set; }

        public DbSet<RolModel> Rol { get; set; }

        public DbSet<PurchasesModel> Purchases { get; set; }

        public DbSet<StockModel> Stock { get; set; }


        //*********** R O L ***********
        public async Task<RolModel?> GetRolById(int id)
        {
            RolModel? rol = await Rol.FirstOrDefaultAsync(p => p.IdRol == id);
            return rol;
        }
        public async Task<RolModel?> CreateRol(RolModel rol)
        {
            EntityEntry<RolModel> response = await Rol.AddAsync(rol);
            await SaveChangesAsync();
            return await GetRolById(response.Entity.IdRol);
        }
        public void UpdateRol(int id, string nombre)
        {
            RolModel? rol = Rol.FirstOrDefault(x => x.IdRol == id);
            if (rol != null)
            {
                rol.Name = nombre;
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
        public async Task<List<PersonModel>> GetAllPerson()
        {
            return await Person.ToListAsync();
        }
        public async Task<PersonModel?> GetPersonById(int id)
        {
            PersonModel? person = await Person.FirstOrDefaultAsync(p => p.IdPerson == id);
            return person;
        }
        public async Task<PersonModel?> CreatePerson(PersonModel person)
        {
            EntityEntry<PersonModel> response = await Person.AddAsync(person);
            await SaveChangesAsync();
            return await GetPersonById(response.Entity.IdPerson);
        }

        public void UpdatePerson(int id, string usuario, string contrasenia)
        {
            PersonModel? person = Person.FirstOrDefault(x => x.IdPerson == id);
            if (person != null)
            {
                person.Mail = usuario;
                person.Password = contrasenia;
                SaveChanges();
            }
        }
        public void DeletePerson(int id)
        {
            PersonModel? persona = Person.FirstOrDefault(x => x.IdPerson == id);
            if (persona != null)
            {
                Person.Remove(persona);
                SaveChanges();
            }
        }

        public async Task<PersonModel?> Login(string usuario, string contrasenia)
        {
            PersonModel? person = await Person.FirstOrDefaultAsync(p => p.Mail == usuario);
            person = await Person.FirstOrDefaultAsync(p => p.Password == contrasenia);
            return person;
        }


        //*********** C O M P R A ***********
        public async Task<List<PurchasesModel>> GetAllPurchases()
        {
            return await Purchases.ToListAsync();
        }
        public async Task<PurchasesModel?> GetPurchaseById(int id)
        {
            PurchasesModel? compra = await Purchases.FirstOrDefaultAsync(p => p.IdPurchase == id);
            return compra;
        }
        public async Task<PurchasesModel?> CreatePurchases(PurchasesModel purchase)
        {
            EntityEntry<PurchasesModel> response = await Purchases.AddAsync(purchase);

            PersonModel? person = Person.FirstOrDefault(x => x.IdPerson == purchase.IdPerson);
            if (person != null)
            {
                person.AccountMoney = ((decimal)person.AccountMoney) - (decimal)purchase.Total;
            }

            await SaveChangesAsync();
            return await GetPurchaseById(response.Entity.IdPurchase);
        }
        public void UpdatePurchase(int id, int cantidad, decimal total)
        {
            PurchasesModel? purchase = Purchases.FirstOrDefault(x => x.IdPurchase == id);
            if (purchase != null)
            {
                purchase.Quantity = cantidad;
                purchase.Total = total;
                SaveChanges();
            }
        }
        public void DeletePurchase(int id)
        {
            PurchasesModel? purchase = Purchases.FirstOrDefault(x => x.IdPurchase == id);
            if (purchase != null)
            {
                Purchases.Remove(purchase);
                SaveChanges();
            }
        }


        public async Task<List<PurchasesModel>> HistoryPurchases(int idCuenta)
        {
            return await Purchases.Where(p => p.IdPerson == idCuenta).ToListAsync();
        }
    }
}