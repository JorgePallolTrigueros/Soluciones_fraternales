using System.Data.Entity;
using Ejemplo_importante.datos.Entities;

namespace Ejemplo_importante.datos
{
    public class SecondDbContext : DbContext
    {
        public SecondDbContext() : base("name=SecondDatabase")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
