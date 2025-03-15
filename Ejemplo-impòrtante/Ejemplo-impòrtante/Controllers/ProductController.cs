using System;
using System.Web.Mvc;
using Ejemplo_importante.Interfaces;
using Ejemplo_importante.datos.Dto;

namespace Ejemplo_importante.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // ✅ 1. Página principal
        public ActionResult Index()
        {
            return View();
        }

        // ✅ 2. Mostrar la vista parcial de "Detalles" en un modal
        public PartialViewResult Details(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return PartialView("_Error", new { message = "Producto no encontrado." });

            return PartialView("Details", product);
        }

        // ✅ 3. Mostrar la vista parcial de "Crear" en un modal
        public PartialViewResult Create()
        {
            return PartialView("Create");
        }

        // ✅ 4. Crear un nuevo producto (POST, AJAX)
        [HttpPost]
        public JsonResult Create(ProductDto product)
        {
            try
            {
                if (product == null || string.IsNullOrWhiteSpace(product.ProductName) || product.Price <= 0)
                {
                    return Json(new { success = false, message = "Datos inválidos." });
                }

                _productService.AddProduct(product);
                return Json(new { success = true, message = "Producto agregado correctamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al agregar el producto: " + ex.Message });
            }
        }

        // ✅ 5. Mostrar la vista parcial de "Editar" en un modal
        public PartialViewResult Edit(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return PartialView("_Error", new { message = "Producto no encontrado." });

            return PartialView("Edit", product);
        }

        // ✅ 6. Actualizar un producto (POST, AJAX)
        [HttpPost]
        public JsonResult Edit(ProductDto product)
        {
            try
            {
                if (product == null || product.ProductId <= 0 || string.IsNullOrWhiteSpace(product.ProductName) || product.Price <= 0)
                {
                    return Json(new { success = false, message = "Datos inválidos." });
                }

                _productService.UpdateProduct(product);
                return Json(new { success = true, message = "Producto actualizado correctamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al actualizar el producto: " + ex.Message });
            }
        }

        // ✅ 7. Mostrar la vista parcial de "Eliminar" en un modal
        public PartialViewResult Delete(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return PartialView("_Error", new { message = "Producto no encontrado." });

            return PartialView("Delete", product);
        }

        // ✅ 8. Eliminar un producto (POST, AJAX)
        [HttpPost]
        public JsonResult DeleteConfirmed(int id)
        {
            try
            {
                if (id <= 0)
                    return Json(new { success = false, message = "ID inválido." });

                var product = _productService.GetProductById(id);
                if (product == null)
                    return Json(new { success = false, message = "Producto no encontrado." });

                _productService.DeleteProduct(id);
                return Json(new { success = true, message = "Producto eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al eliminar el producto: " + ex.Message });
            }
        }

        // ✅ 9. Obtener todos los productos en JSON (para cargar en una tabla, por ejemplo)
        [HttpGet]
        public JsonResult GetProducts()
        {
            try
            {
                var products = _productService.GetAllProducts();
                return Json(products, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al obtener los productos: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // ✅ 10. Obtener un producto por ID en JSON
        [HttpGet]
        public JsonResult GetProductById(int id)
        {
            try
            {
                if (id <= 0)
                    return Json(new { success = false, message = "ID inválido." }, JsonRequestBehavior.AllowGet);

                var product = _productService.GetProductById(id);
                if (product == null)
                    return Json(new { success = false, message = "Producto no encontrado." }, JsonRequestBehavior.AllowGet);

                return Json(new { success = true, data = product }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al obtener el producto: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
