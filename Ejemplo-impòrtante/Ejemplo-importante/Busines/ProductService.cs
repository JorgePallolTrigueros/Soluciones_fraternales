using System.Collections.Generic;
using System.Linq;
using Ejemplo_importante.Interfaces;
using Ejemplo_importante.datos.Dto;
using Ejemplo_importante.datos.Interfaces;
using Ejemplo_importante.datos.Entities;
using System;

namespace Ejemplo_importante.Busines
{
   
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Implementación de GetAllProducts
        public IEnumerable<ProductDto> GetAllProducts()
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

        // Implementación de GetProductById
        public ProductDto GetProductById(int productId)
        {
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

        // Implementación de AddProduct
        public void AddProduct(ProductDto productDto)
        {
            // Convertir ProductDto a Product
            var product = new Product
            {
                ProductName = productDto.ProductName,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId
            };

            // Llamar al método del repositorio pasando un objeto Product
            _productRepository.AddProduct(product);
        }

        // Implementación de UpdateProduct
        public void UpdateProduct(ProductDto productDto)
        {
            // Obtener el producto existente desde la base de datos
            var existingProduct = _productRepository.GetProductById(productDto.ProductId);

            if (existingProduct == null)
            {
                throw new ArgumentException("El producto no existe.");
            }

            // Actualizar las propiedades del producto existente con los valores del DTO
            existingProduct.ProductName = productDto.ProductName;
            existingProduct.Price = productDto.Price;
            existingProduct.CategoryId = productDto.CategoryId;

            // Llamar al método del repositorio para actualizar el producto en la base de datos
            _productRepository.UpdateProduct(existingProduct);
        }

        // Implementación de DeleteProduct
        public void DeleteProduct(int productId)
        {
            var product = _productRepository.GetProductById(productId);
            if (product == null)
            {
                throw new ArgumentException("El producto no existe.");
            }

            _productRepository.DeleteProduct(productId);
        }
    }
}