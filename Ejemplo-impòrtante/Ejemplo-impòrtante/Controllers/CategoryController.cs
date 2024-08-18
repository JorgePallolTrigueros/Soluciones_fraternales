using System.Web.Mvc;
using Ejemplo_importante.Interfaces;
using Ejemplo_importante.datos.Dto;

namespace Ejemplo_impòrtante.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var categories = _categoryService.GetAllCategories();
            return View(categories);
        }

        public ActionResult Details(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryDto category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.AddCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public ActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(CategoryDto category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public ActionResult Delete(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}