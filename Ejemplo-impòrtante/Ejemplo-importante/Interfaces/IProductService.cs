using Ejemplo_importante.datos.Dto;
using System.Collections.Generic;

namespace Ejemplo_importante.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProducts();
        ProductDto GetProductById(int productId);
        void AddProduct(ProductDto product);
        void UpdateProduct(ProductDto product);
        void DeleteProduct(int productId);
    }
}
