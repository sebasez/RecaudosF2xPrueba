using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recaudo.DTOs;
using Recaudo.Presenters;
using Recaudo.UseCasesPorts.ReporteRecaudoPosts;

namespace Recaudo.WebAppAngular.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly IGetReporteRecaudoInputPort _inputPort;
        private readonly IGetReporteRecaudoOutputPort _outputPort;
        public ReporteController(IGetReporteRecaudoInputPort inputPort, IGetReporteRecaudoOutputPort outputPort)
        {
            _inputPort = inputPort;
            _outputPort = outputPort;
        }

        [HttpGet]
        public async Task<ReporteRecaudoDTO> Get(GetReporteRecaudoDTO reporte)
        {
            await _inputPort.Handle(reporte.FechaInicio, reporte.FechaFin);
            return ((IPresenter<ReporteRecaudoDTO>)_outputPort).Content;
        }
    }
}
