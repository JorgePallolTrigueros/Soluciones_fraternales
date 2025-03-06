using Ejemplo_importante.datos.Dto;
using Ejemplo_importante.datos.Entities;
using Ejemplo_importante.datos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ejemplo_importante.datos.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SecondDbContext _context;

        public CategoryRepository(SecondDbContext context)
        {
            _context = context;
        }

        // ✅ Obtener todas las categorías
        public IEnumerable<Category> GetAllCategories()
        {
            try
            {
                return _context.Categories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las categorías: " + ex.Message);
            }
        }

        // ✅ Obtener una categoría por ID
        public Category GetCategoryById(int categoryId)
        {
            try
            {
                var category = _context.Categories.Find(categoryId);
                if (category == null)
                {
                    throw new Exception("Categoría no encontrada.");
                }
                return category;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la categoría: " + ex.Message);
            }
        }





        // ✅ Agregar una nueva categoría
        public void AddCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category), "La categoría no puede ser nula.");
            }

            _context.Categories.Add(category);
            _context.SaveChanges();
        }






        // ✅ Actualizar una categoría existente
        public void UpdateCategory(Category category)
        {
            try
            {
                if (category == null)
                {
                    throw new ArgumentException("La categoría no puede ser nula.");
                }

                var existingCategory = _context.Categories.Find(category.CategoryId);
                if (existingCategory == null)
                {
                    throw new Exception("La categoría no existe.");
                }

                _context.Entry(existingCategory).CurrentValues.SetValues(category);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la categoría: " + ex.Message);
            }
        }

        // ✅ Eliminar una categoría
        public void DeleteCategory(int categoryId)
        {
            try
            {
                var category = _context.Categories.Find(categoryId);
                if (category == null)
                {
                    throw new Exception("La categoría no existe.");
                }

                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la categoría: " + ex.Message);
            }
        }


    }
}
