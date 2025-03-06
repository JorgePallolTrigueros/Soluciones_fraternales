using System;
using System.Collections.Generic;
using System.Linq;
using Ejemplo_importante.Interfaces;
using Ejemplo_importante.datos.Dto;
using Ejemplo_importante.datos.Interfaces;
using Ejemplo_importante.datos.Entities;

namespace Ejemplo_importante.Busines
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // ✅ Obtener todos los productos
        public IEnumerable<ProductDto> GetAllProducts()
        {
            try
            {
                var products = _productRepository.GetAllProducts();
                return products.Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category?.CategoryName
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los productos: " + ex.Message);
            }
        }

        // ✅ Obtener un producto por su ID
        public ProductDto GetProductById(int productId)
        {
            try
            {
                if (productId <= 0)
                {
                    throw new ArgumentException("El ID del producto no es válido.");
                }

                var product = _productRepository.GetProductById(productId);
                if (product == null)
                {
                    return null;
                }

                return new ProductDto
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category?.CategoryName
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el producto: " + ex.Message);
            }
        }

        // ✅ Agregar un nuevo producto
        public void AddProduct(ProductDto productDto)
        {
            try
            {
                if (productDto == null || string.IsNullOrWhiteSpace(productDto.ProductName) || productDto.Price <= 0)
                {
                    throw new ArgumentException("Datos del producto inválidos.");
                }

                var product = new Product
                {
                    ProductName = productDto.ProductName,
                    Price = productDto.Price,
                    CategoryId = productDto.CategoryId
                };

                _productRepository.AddProduct(product);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el producto: " + ex.Message);
            }
        }

        // ✅ Actualizar un producto existente
        public void UpdateProduct(ProductDto productDto)
        {
            try
            {
                if (productDto == null || productDto.ProductId <= 0 || string.IsNullOrWhiteSpace(productDto.ProductName) || productDto.Price <= 0)
                {
                    throw new ArgumentException("Datos del producto inválidos.");
                }

                var existingProduct = _productRepository.GetProductById(productDto.ProductId);
                if (existingProduct == null)
                {
                    throw new Exception("El producto no existe.");
                }

                existingProduct.ProductName = productDto.ProductName;
                existingProduct.Price = productDto.Price;
                existingProduct.CategoryId = productDto.CategoryId;

                _productRepository.UpdateProduct(existingProduct);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el producto: " + ex.Message);
            }
        }

        // ✅ Eliminar un producto
        public void DeleteProduct(int productId)
        {
            try
            {
                if (productId <= 0)
                {
                    throw new ArgumentException("El ID del producto no es válido.");
                }

                var product = _productRepository.GetProductById(productId);
                if (product == null)
                {
                    throw new Exception("El producto no existe.");
                }

                _productRepository.DeleteProduct(productId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el producto: " + ex.Message);
            }
        }
    }
}
