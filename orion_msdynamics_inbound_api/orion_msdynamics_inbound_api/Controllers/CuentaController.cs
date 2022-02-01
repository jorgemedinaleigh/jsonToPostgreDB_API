using System.Text.Json;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using orion_msdynamics_inbound_api.Data;
using orion_msdynamics_inbound_api.Models;

namespace orion_msdynamics_inbound_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : Controller
    {
        private readonly CuentaRepository _cuentaRepository = new CuentaRepository();

        [HttpPost]
        public void CuentaLogger(Cuenta cuenta)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string cuentaJson = JsonSerializer.Serialize(cuenta, options);
            _cuentaRepository.AddCuenta(cuentaJson);
        }
    }
}
