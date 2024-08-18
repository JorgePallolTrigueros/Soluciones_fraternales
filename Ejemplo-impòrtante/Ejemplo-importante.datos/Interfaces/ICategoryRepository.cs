using Ejemplo_importante.datos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_importante.datos.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int categoryId);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int categoryId);
    }
    }
