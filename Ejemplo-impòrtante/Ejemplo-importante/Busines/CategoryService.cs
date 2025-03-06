using System.Collections.Generic;
using System.Linq;
using Ejemplo_importante.Interfaces;
using Ejemplo_importante.datos.Dto;
using Ejemplo_importante.datos.Interfaces;
using Ejemplo_importante.datos.Entities;
using System;
using Ejemplo_importante;


namespace Ejemplo_importante.Interfaces
{
    public class CategoryService :ICategoryService

    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // ✅ Obtener todas las categorías con validación
        public IEnumerable<CategoryDto> GetAllCategories()
        {
            try
            {
                var categories = _categoryRepository.GetAllCategories();
                return categories.Select(c => new CategoryDto
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Description = c.Description
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las categorías: " + ex.Message);
            }
        }

        // ✅ Obtener una categoría por ID con validación
        public CategoryDto GetCategoryById(int categoryId)
        {
            try
            {
                if (categoryId <= 0)
                {
                    throw new ArgumentException("ID de categoría inválido.");
                }

                var category = _categoryRepository.GetCategoryById(categoryId);
                if (category == null)
                {
                    throw new Exception("Categoría no encontrada.");
                }

                return new CategoryDto
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Description = category.Description
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la categoría: " + ex.Message);
            }
        }

        // ✅ Agregar una categoría con validación
        public void AddCategory(CategoryDto categoryDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(categoryDto.CategoryName))
                {
                    throw new ArgumentException("El nombre de la categoría es obligatorio.");
                }

                var category = new Category
                {
                    CategoryName = categoryDto.CategoryName,
                    Description = categoryDto.Description
                };

                _categoryRepository.AddCategory(category);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la categoría: " + ex.Message);
            }
        }

        // ✅ Actualizar una categoría con validación
        public void UpdateCategory(CategoryDto categoryDto)
        {
            try
            {
                if (categoryDto.CategoryId <= 0)
                {
                    throw new ArgumentException("ID de categoría inválido.");
                }

                var existingCategory = _categoryRepository.GetCategoryById(categoryDto.CategoryId);
                if (existingCategory == null)
                {
                    throw new Exception("La categoría no existe.");
                }

                existingCategory.CategoryName = categoryDto.CategoryName;
                existingCategory.Description = categoryDto.Description;

                _categoryRepository.UpdateCategory(existingCategory);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la categoría: " + ex.Message);
            }
        }

        // ✅ Eliminar una categoría con validación
        public void DeleteCategory(int categoryId)
        {
            try
            {
                if (categoryId <= 0)
                {
                    throw new ArgumentException("ID de categoría inválido.");
                }

                var category = _categoryRepository.GetCategoryById(categoryId);
                if (category == null)
                {
                    throw new Exception("La categoría no existe.");
                }

                _categoryRepository.DeleteCategory(categoryId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la categoría: " + ex.Message);
            }
        }
    }
}

