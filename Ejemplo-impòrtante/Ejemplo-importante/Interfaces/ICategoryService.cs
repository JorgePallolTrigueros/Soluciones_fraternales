using Ejemplo_importante.datos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
