using System.Collections.Generic;
using System.Linq;
using Ejemplo_importante.Interfaces;
using Ejemplo_importante.datos.Dto;
using Ejemplo_importante.datos.Interfaces;
using Ejemplo_importante.datos.Entities;
using System;


namespace Ejemplo_importante.Busines
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = _categoryRepository.GetAllCategories();
            return categories.Select(c => new CategoryDto
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                Description = c.Description
            });
        }

        public CategoryDto GetCategoryById(int categoryId)
        {
            var category = _categoryRepository.GetCategoryById(categoryId);
            if (category == null)
            {
                return null;
            }

            return new CategoryDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
        }

        public void AddCategory(CategoryDto categoryDto)
        {
            var category = new Category
            {
                CategoryName = categoryDto.CategoryName,
                Description = categoryDto.Description
            };

            _categoryRepository.AddCategory(category);
        }

        public void UpdateCategory(CategoryDto categoryDto)
        {
            var existingCategory = _categoryRepository.GetCategoryById(categoryDto.CategoryId);
            if (existingCategory == null)
            {
                throw new ArgumentException("La categoría no existe.");
            }

            existingCategory.CategoryName = categoryDto.CategoryName;
            existingCategory.Description = categoryDto.Description;

            _categoryRepository.UpdateCategory(existingCategory);
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _categoryRepository.GetCategoryById(categoryId);
            if (category == null)
            {
                throw new ArgumentException("La categoría no existe.");
            }

            _categoryRepository.DeleteCategory(categoryId);
        }
    }
}
