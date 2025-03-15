using Ejemplo_importante.datos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_importante.datos.Dto
{
    public class ProductDto
    {
        public int ProductId { get; set; }           // Identificador del Producto
        public string ProductName { get; set; }      // Nombre del Producto
        public decimal Price { get; set; }           // Precio del Producto
        public int CategoryId { get; set; }          // Identificador de la Categoría
        public string CategoryName { get; set; }     // Nombre de la Categoría
        public virtual Category Category { get; set; }
    }
}
