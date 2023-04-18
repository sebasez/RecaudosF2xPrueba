namespace Recaudo.UseCasesPorts.ProcesarDatosPorts
{
    public interface IProcesoDatosInputPort
    {
        Task Handle(DateTime fecha);
    }
}
