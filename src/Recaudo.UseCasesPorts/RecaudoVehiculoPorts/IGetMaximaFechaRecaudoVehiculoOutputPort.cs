namespace Recaudo.UseCasesPorts.RecaudoVehiculoPorts
{
    public interface IGetMaximaFechaRecaudoVehiculoOutputPort
    {
        Task Handle(DateTime fachaMaxima);
    }
}
