namespace Recaudo.UseCasesPorts.ConteoVehiculoPorts
{
    public interface IGetMaximaFechaConteoVehiculoOutputPort
    {
        Task Handle(DateTime fachaMaxima);
    }
}
