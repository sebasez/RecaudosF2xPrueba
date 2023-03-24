using Recaudo.DTOs;
using Recaudo.UseCasesPorts.ReporteRecaudoPosts;

namespace Recaudo.Presenters.ReporteRecaudo
{
    public class GetReporteVehiculoPresenter : IGetReporteRecaudoOutputPort, IPresenter<IEnumerable<ReporteRecaudoDTO>>
    {
        public IEnumerable<ReporteRecaudoDTO> Content { get; private set; }

        public Task Handle(IEnumerable<ReporteRecaudoDTO> reporteRecaudos)
        {
            Content= reporteRecaudos;
            return Task.CompletedTask;
        }
    }
}
