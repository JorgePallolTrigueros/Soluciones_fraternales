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

        // ✅ Cargar la vista principal
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Details(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound("Producto no encontrado.");
            }
            return View(product);
        }




        // ✅ Obtener todos los productos en formato JSON
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

        // ✅ Obtener detalles de un producto en JSON
        [HttpGet]
        public JsonResult GetProductById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return Json(new { success = false, message = "ID inválido." }, JsonRequestBehavior.AllowGet);
                }

                var product = _productService.GetProductById(id);
                if (product == null)
                {
                    return Json(new { success = false, message = "Producto no encontrado." }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { success = true, data = product }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al obtener el producto: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult Create()
        {
            return View(); // No se necesita buscar un producto porque es nuevo
        }



        // ✅ Crear un nuevo producto con `fetch`
        [HttpPost]
        public JsonResult Create(ProductDto product)
        {
            try
            {
                if (product == null || string.IsNullOrWhiteSpace(product.ProductName) || product.Price <= 0)
                {
                    return Json(new { success = false, message = "Datos del producto inválidos." });
                }

                _productService.AddProduct(product);
                return Json(new { success = true, message = "Producto agregado correctamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al agregar el producto: " + ex.Message });
            }
        }

        // ✅ Mostrar la vista de edición con el producto cargado
        public ActionResult Edit(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // ✅ Actualizar un producto con `fetch`
        [HttpPost]
        public JsonResult Edit(ProductDto product)
        {
            try
            {
                if (product == null || product.ProductId <= 0 || string.IsNullOrWhiteSpace(product.ProductName) || product.Price <= 0)
                {
                    return Json(new { success = false, message = "Datos del producto inválidos." });
                }

                _productService.UpdateProduct(product);
                return Json(new { success = true, message = "Producto actualizado correctamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al actualizar el producto: " + ex.Message });
            }
        }

        // ✅ Eliminar un producto con `fetch`
        // ✅ ELIMINAR PRODUCTO (JSON)
        [HttpPost]
        public JsonResult DeleteConfirmed(int id)
        {
            try
            {
                Console.WriteLine("ID recibido en el controlador: " + id); // 🛠 Depurar en la consola del servidor

                if (id <= 0)
                {
                    return Json(new { success = false, message = "ID inválido." });
                }

                var product = _productService.GetProductById(id);
                if (product == null)
                {
                    return Json(new { success = false, message = "Producto no encontrado." });
                }

                _productService.DeleteProduct(id);
                return Json(new { success = true, message = "Producto eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al eliminar el producto: " + ex.Message });
            }
        }






        public ActionResult Delete(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product); // ✅ Retorna la vista `Delete.cshtml` con el producto cargado.
        }






    }
}
