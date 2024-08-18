using System.Web.Mvc;
using Ejemplo_importante.Interfaces;
using Ejemplo_importante.datos.Dto;

namespace Ejemplo_impòrtante.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public ActionResult Index()
        {
            var customers = _customerService.GetAllCustomers();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerDto customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.AddCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(CustomerDto customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.UpdateCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public ActionResult Delete(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _customerService.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}
