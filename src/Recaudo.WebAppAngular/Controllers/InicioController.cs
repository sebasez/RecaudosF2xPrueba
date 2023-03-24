using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recaudo.ConsultaRecaudo;

namespace Recaudo.WebAppAngular.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InicioController : ControllerBase
    {
        [HttpGet]   
        public IActionResult Get()
        {
            RecurringJob.AddOrUpdate(
            "Consulta Datos",
            () => new RecaudoObtenerConteoVehiculos().ObtenerConteo(new ConsultaRecaudo.Entities.FiltroConsultaGeneralRequest() { FechaConsulta = DateTime.Now}),
            Cron.Daily);
            return Ok();
        }
    }
}
