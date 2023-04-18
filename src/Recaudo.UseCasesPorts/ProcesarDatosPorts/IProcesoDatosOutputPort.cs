namespace Recaudo.UseCasesPorts.ProcesarDatosPorts
{
    public interface IProcesoDatosOutputPort
    {
        Task Handle(DateTime fechaProcesadaActual);
    }
}
