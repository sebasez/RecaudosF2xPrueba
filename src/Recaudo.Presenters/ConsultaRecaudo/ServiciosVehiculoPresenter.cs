using Recaudo.UseCasesPorts.ProcesarDatosPorts;

namespace Recaudo.Presenters.ConsultaRecaudo
{
    public class ServiciosVehiculoPresenter : IProcesoDatosOutputPort, IPresenter<DateTime>
    {
        public DateTime Content { get; private set; }

        public Task Handle(DateTime fecha)
        {
            Content = fecha;
            return Task.CompletedTask;
        }
    }
}
