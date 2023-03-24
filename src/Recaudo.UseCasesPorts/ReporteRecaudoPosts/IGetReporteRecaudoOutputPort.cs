using Recaudo.DTOs;

namespace Recaudo.UseCasesPorts.ReporteRecaudoPosts
{
    public interface IGetReporteRecaudoOutputPort
    {
        Task Handle(IEnumerable<ReporteRecaudoDTO> reporteRecaudos);
    }
}
