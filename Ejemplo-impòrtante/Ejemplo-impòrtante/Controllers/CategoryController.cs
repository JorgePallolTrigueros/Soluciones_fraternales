using System;
using System.Web.Mvc;
using Ejemplo_importante.Interfaces;
using Ejemplo_importante.datos.Dto;

namespace Ejemplo_importante.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // ✅ Mostrar la vista principal (Index.cshtml)
        public ActionResult Index()
        {
            return View();
        }

        // ✅ LISTAR TODAS LAS CATEGORÍAS (JSON)
        [HttpGet]
        public JsonResult GetCategories()
        {
            try
            {
                var categories = _categoryService.GetAllCategories();
                return Json(categories, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al obtener las categorías: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // ✅ OBTENER DETALLES DE UNA CATEGORÍA (JSON)
        [HttpGet]
        public JsonResult GetCategoryById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return Json(new { success = false, message = "ID de categoría inválido." }, JsonRequestBehavior.AllowGet);
                }

                var category = _categoryService.GetCategoryById(id);
                if (category == null)
                {
                    return Json(new { success = false, message = "Categoría no encontrada." }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { success = true, data = category }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al obtener la categoría: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // ✅ Mostrar la vista de Crear (Create.cshtml)
        public ActionResult Create()
        {
            return View();
        }

        // ✅ CREAR CATEGORÍA (JSON)
        [HttpPost]
        public JsonResult Create(CategoryDto category)
        {
            try
            {
                if (category == null || string.IsNullOrWhiteSpace(category.CategoryName))
                {
                    return Json(new { success = false, message = "Datos de categoría inválidos." });
                }

                _categoryService.AddCategory(category);
                return Json(new { success = true, message = "Categoría agregada correctamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al agregar la categoría: " + ex.Message });
            }
        }





        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return HttpNotFound();
            }

            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }










        // ✅ Mostrar la vista de Editar (Edit.cshtml)
        public ActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // ✅ EDITAR CATEGORÍA (JSON)
        [HttpPost]
        public JsonResult Edit(CategoryDto category)
        {
            try
            {
                if (category == null || category.CategoryId <= 0 || string.IsNullOrWhiteSpace(category.CategoryName))
                {
                    return Json(new { success = false, message = "Datos de categoría inválidos." });
                }

                _categoryService.UpdateCategory(category);
                return Json(new { success = true, message = "Categoría actualizada correctamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al actualizar la categoría: " + ex.Message });
            }
        }
        // ✅ Mostrar la vista de confirmación de eliminación
        public ActionResult Delete(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // ✅ ELIMINAR CATEGORÍA (AHORA SIN ERROR DE DUPLICADO)
        [HttpPost]
        public JsonResult DeleteConfirmed(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return Json(new { success = false, message = "ID de categoría inválido." });
                }

                _categoryService.DeleteCategory(id);
                return Json(new { success = true, message = "Categoría eliminada correctamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al eliminar la categoría: " + ex.Message });
            }
        }
    }
}
