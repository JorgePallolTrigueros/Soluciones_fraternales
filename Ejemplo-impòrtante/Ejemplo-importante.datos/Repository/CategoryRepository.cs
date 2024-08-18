using System;
using System.Collections.Generic;
using System.Linq;
using Ejemplo_importante.datos.Entities;
using Ejemplo_importante.datos.Interfaces;

namespace Ejemplo_importante.datos.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SecondDbContext _context;

        public CategoryRepository(SecondDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories.Find(categoryId);
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Entry(category).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _context.Categories.Find(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}