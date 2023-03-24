namespace Recaudo.UseCasesPorts.ReporteRecaudoPosts
{
    public interface IGetReporteRecaudoInputPort
    {
        Task Handle(DateTime fachaInicio, DateTime fechaFin);
    }
}
