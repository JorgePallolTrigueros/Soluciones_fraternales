using System;
using System.Collections.Generic;
using System.Linq;
using Ejemplo_importante.datos.Dto;
using Ejemplo_importante.datos.Entities;
using Ejemplo_importante.datos.Interfaces;
using System.Data.Entity;





namespace Ejemplo_importante.datos.Repository

    {
        public class ProductRepository : IProductRepository
        {
            private readonly SecondDbContext _context;

            public ProductRepository(SecondDbContext context)
            {
                _context = context;
            }

            // Método para obtener todos los productos
            public IEnumerable<Product> GetAllProducts() // Devuelve IEnumerable<Product>
            {
                return _context.Products.Include(p => p.Category).ToList();
            }

            // Método para obtener un producto por ID
            public Product GetProductById(int productId) // Devuelve Product
            {
                return _context.Products.Include(p => p.Category)
                                         .FirstOrDefault(p => p.ProductId == productId);
            }

            // Método para agregar un nuevo producto
            public void AddProduct(Product product)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }

            // Método para actualizar un producto existente
            public void UpdateProduct(Product product)
            {
                _context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }

            // Método para eliminar un producto
            public void DeleteProduct(int productId)
            {
                var product = _context.Products.Find(productId);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                }
            }
        }
    }
