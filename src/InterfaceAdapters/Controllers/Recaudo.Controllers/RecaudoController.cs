using Microsoft.AspNetCore.Mvc;
using Recaudo.DTOs;
using Recaudo.Presenters;
using Recaudo.UseCasesPorts.RecaudoVehiculoPorts;

namespace Recaudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecaudoController
    {
        private readonly IGetRecaudoVehiculosInputPort _inputPort;
        private readonly IGetRecaudoVehiculosOutputPort _outputPort;
        public RecaudoController(IGetRecaudoVehiculosInputPort inputPort, IGetRecaudoVehiculosOutputPort outputPort)
        {
            _inputPort = inputPort;
            _outputPort = outputPort;
        }

        [HttpGet]
        public async Task<IEnumerable<RecaudoVehiculoDTO>> Get()
        {
            await _inputPort.Handle();
            return ((IPresenter<IEnumerable<RecaudoVehiculoDTO>>)_outputPort).Content;
        }
    }
}
