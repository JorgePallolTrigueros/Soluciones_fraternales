using Ejemplo_importante.datos.Dto;
using Ejemplo_importante.datos.Entities;
using System.Collections.Generic;

namespace Ejemplo_importante.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAllCategories();
        CategoryDto GetCategoryById(int categoryId);
        void AddCategory(CategoryDto category);
        void UpdateCategory(CategoryDto category);
        void DeleteCategory(int categoryId);

    }
}
