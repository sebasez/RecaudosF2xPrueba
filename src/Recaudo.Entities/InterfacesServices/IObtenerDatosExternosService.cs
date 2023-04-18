using Recaudo.Entities.POCOs;

namespace Recaudo.Entities.InterfacesServices
{
    public interface IObtenerDatosExternosService
    {
        Task<string> ObtenerDatos(FiltroConsultaGeneralRequest filtroConsulta);
    }
}
