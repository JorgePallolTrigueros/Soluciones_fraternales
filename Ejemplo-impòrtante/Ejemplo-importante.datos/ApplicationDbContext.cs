using System.Data.Entity;
using Ejemplo_importante.datos.Entities;


namespace Ejemplo_importante.datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=SqlConnectionString")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}