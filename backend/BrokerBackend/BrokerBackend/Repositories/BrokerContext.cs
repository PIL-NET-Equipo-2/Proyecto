using BrokerBackend.Models;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;

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
    }
}