using Microsoft.AspNetCore.Mvc;
using Recaudo.DTOs;
using Recaudo.Presenters;
using Recaudo.UseCasesPorts.ConteoVehiculoPorts;

namespace Recaudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConteoController
    {
        private readonly IGetConteoVehiculosInputPort _inputPort;
        private readonly IGetConteoVehiculosOutputPort _outputPort;
        public ConteoController(IGetConteoVehiculosInputPort inputPort, IGetConteoVehiculosOutputPort outputPort)
        {
            _inputPort = inputPort;
            _outputPort = outputPort;
        }
        [HttpGet]
        public async Task<IEnumerable<ConteoVehiculoDTO>> Get()
        {
            await _inputPort.Handle();
            return ((IPresenter<IEnumerable<ConteoVehiculoDTO>>)_outputPort).Content;
        }
    }
}
