using Microsoft.AspNetCore.Mvc;

namespace orion_msdynamics_inbound_api.Controllers
{
    public class CuentaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
