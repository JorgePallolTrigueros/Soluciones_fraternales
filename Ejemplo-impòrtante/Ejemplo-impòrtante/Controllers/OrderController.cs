using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ejemplo_importante.datos.Dto;
using Ejemplo_importante.Interfaces;

namespace Ejemplo_importante.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // ✅ Mostrar la lista de órdenes
        public ActionResult Index()
        {
            var orders = _orderService.GetAllOrders();
            return View(orders);
        }

        // ✅ Mostrar detalles de una orden
        public ActionResult Details(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // ✅ Mostrar vista de creación
        public ActionResult Create()
        {
            return View();
        }

        // ✅ Crear una nueva orden
        [HttpPost]
        public ActionResult Create(OrderDto order)
        {
            if (ModelState.IsValid)
            {
                _orderService.AddOrder(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // ✅ Mostrar vista de edición
        public ActionResult Edit(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // ✅ Editar una orden
        [HttpPost]
        public ActionResult Edit(OrderDto order)
        {
            if (ModelState.IsValid)
            {
                _orderService.UpdateOrder(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }
        public ActionResult Delete(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View("Delete", order); // ⬅️ Asegurar que devuelve la vista Delete.cshtml
        }

        // ✅ Renombrar este método a `DeleteConfirmed`
        [HttpPost]
        public JsonResult DeleteConfirmed(int id) // ⬅️ Cambio aquí para evitar conflicto
        {
            try
            {
                if (id <= 0)
                {
                    return Json(new { success = false, message = "ID inválido." });
                }

                var order = _orderService.GetOrderById(id);
                if (order == null)
                {
                    return Json(new { success = false, message = "Orden no encontrada." });
                }

                _orderService.DeleteOrder(id);
                return Json(new { success = true, message = "Orden eliminada correctamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al eliminar la orden: " + ex.Message });
            }
        }
    }
}