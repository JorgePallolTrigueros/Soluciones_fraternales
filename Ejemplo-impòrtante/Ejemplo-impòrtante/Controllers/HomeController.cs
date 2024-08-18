using System.Web.Mvc;

namespace Ejemplo_impòrtante.Controllers
{
    public class HomeController : Controller
    {
        // Acción que responde a la ruta "/"
        public ActionResult Index()
        {
            return View();  // Renderiza la vista Index.cshtml de la carpeta Home
        }
    }
}