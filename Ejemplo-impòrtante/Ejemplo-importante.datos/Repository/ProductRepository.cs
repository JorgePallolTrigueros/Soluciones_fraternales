using System;
using System.Collections.Generic;
using System.Linq;
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

        // ✅ Obtener todos los productos con su categoría
        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                return _context.Products.Include(p => p.Category).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los productos: " + ex.Message);
            }
        }

        // ✅ Obtener un producto por su ID
        public Product GetProductById(int productId)
        {
            try
            {
                if (productId <= 0)
                {
                    throw new ArgumentException("El ID del producto no es válido.");
                }

                return _context.Products.Include(p => p.Category)
                                         .FirstOrDefault(p => p.ProductId == productId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el producto: " + ex.Message);
            }
        }

        // ✅ Agregar un nuevo producto
        public void AddProduct(Product product)
        {
            try
            {
                if (product == null)
                {
                    throw new ArgumentException("El producto no puede ser nulo.");
                }

                _context.Products.Add(product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el producto: " + ex.Message);
            }
        }

        // ✅ Actualizar un producto existente
        public void UpdateProduct(Product product)
        {
            try
            {
                if (product == null || product.ProductId <= 0)
                {
                    throw new ArgumentException("Datos de producto inválidos.");
                }

                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
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

                var product = _context.Products.Find(productId);
                if (product == null)
                {
                    throw new Exception("El producto no existe.");
                }

                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el producto: " + ex.Message);
            }
        }
    }
}
