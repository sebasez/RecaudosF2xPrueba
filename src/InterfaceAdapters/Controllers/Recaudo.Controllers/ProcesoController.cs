using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Recaudo.DTOs;
using Recaudo.Presenters;
using Recaudo.UseCasesPorts.ProcesarDatosPorts;

namespace Recaudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcesoController
    {
        private readonly IRecurringJobManager _jobClient;
        private readonly IProcesoDatosOutputPort _outputPort;
        private readonly IProcesoDatosInputPort _inputPort;
        private readonly IConfiguration _configuration;
        public ProcesoController(IRecurringJobManager jobClient, IProcesoDatosInputPort inputPort, IProcesoDatosOutputPort outputPort, IConfiguration configuration)
        {
            _jobClient = jobClient;
            _inputPort = inputPort;
            _outputPort = outputPort;
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<bool> Get()
        {
            DateTime fechaInicioDeConsultas = DateTime.Parse(_configuration.GetValue<string>("FechaConsultaInicial") ?? "2021-08-01");
            _jobClient.AddOrUpdate("Carga de Informacion", () =>
                _inputPort.Handle(fechaInicioDeConsultas),
                Cron.Minutely);

            var fechaProcesadaActual = ((IPresenter<DateTime>)_outputPort).Content;
            if (fechaProcesadaActual == DateTime.Now.AddDays(1))
                _jobClient.RemoveIfExists("Carga de Informacion");
            return true;
        }
        [HttpGet("Detener")]
        public async Task<bool> Detener()
        {
            _jobClient.RemoveIfExists("Carga de Informacion");
            _jobClient.RemoveIfExists("");
            return true;
        }
    }
}
