

using Ejemplo_importante.datos.Entities;
using System.Collections.Generic;

namespace Ejemplo_importante.datos.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts(); // Devuelve lista de productos
        Product GetProductById(int productId); // Devuelve un solo producto
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
    }
}
