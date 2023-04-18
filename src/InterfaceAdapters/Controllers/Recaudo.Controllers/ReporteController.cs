using Microsoft.AspNetCore.Mvc;
using Recaudo.DTOs;
using Recaudo.Presenters;
using Recaudo.UseCasesPorts.ReporteRecaudoPosts;

namespace Recaudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController 
    {
        private readonly IGetReporteRecaudoInputPort _inputPort;
        private readonly IGetReporteRecaudoOutputPort _outputPort;
        public ReporteController(IGetReporteRecaudoInputPort inputPort, IGetReporteRecaudoOutputPort outputPort)
        {
            _inputPort = inputPort;
            _outputPort = outputPort;
        }

        [HttpPost]
        public async Task<IEnumerable<ReporteRecaudoDTO>> Get(GetReporteRecaudoDTO reporte)
        {
            await _inputPort.Handle(reporte.FechaInicio, reporte.FechaFin);
            return ((IPresenter<IEnumerable<ReporteRecaudoDTO>>)_outputPort).Content;
        }
    }
}
