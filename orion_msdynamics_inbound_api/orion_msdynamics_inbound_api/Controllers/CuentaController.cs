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
        ResponseData _responseData = new ResponseData();

        [HttpPost]
        public ResponseData CuentaLogger(Cuenta cuenta)
        {
            try
            {
                string cuentaJson = JsonSerializer.Serialize(cuenta);
                _cuentaRepository.AddCuenta(cuentaJson);

                _responseData.status = "Success";
                _responseData.message = "Cuenta registrada en log de base de datos";
                _responseData.statusCode = 0;
            }
            catch (Exception ex)
            {
                _responseData.status = "Failed";
                _responseData.message = "Ocurrio un error al registrar la informacion";
                _responseData.statusCode = ex.GetHashCode();
            }

            return _responseData;
        }
    }
}
