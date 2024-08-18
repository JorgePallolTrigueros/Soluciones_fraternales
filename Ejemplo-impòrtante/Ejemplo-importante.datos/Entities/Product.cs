using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_importante.datos.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        // Foreign key referencing Category
        public int CategoryId { get; set; }

        // Navigation property for the related Category
        public virtual Category Category { get; set; }
    }
}