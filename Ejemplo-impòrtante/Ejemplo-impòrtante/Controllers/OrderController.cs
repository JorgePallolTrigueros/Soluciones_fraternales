using System.Web.Mvc;
using Ejemplo_importante.Interfaces;
using Ejemplo_importante.datos.Dto;

namespace Ejemplo_impòrtante.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public ActionResult Index()
        {
            var orders = _orderService.GetAllOrders();
            return View(orders);
        }

        public ActionResult Details(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        public ActionResult Create()
        {
            return View();
        }

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

        public ActionResult Edit(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

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
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _orderService.DeleteOrder(id);
            return RedirectToAction("Index");
        }
    }
}