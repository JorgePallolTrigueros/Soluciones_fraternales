using Ejemplo_importante.datos.Dto;
using Ejemplo_importante.datos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_importante.datos.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts(); // Trabaja con Product
        Product GetProductById(int productId); // Trabaja con Product
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
    }
}