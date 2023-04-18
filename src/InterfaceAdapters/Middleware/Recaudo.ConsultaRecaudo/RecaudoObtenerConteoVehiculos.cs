using Recaudo.Entities.InterfacesServices;
using RestSharp;

namespace Recaudo.ConsultaRecaudo
{
    public class RecaudoObtenerConteoVehiculos : IObtenerDatosExternosService
    {
        public async Task<string> ObtenerDatos(Recaudo.Entities.POCOs.FiltroConsultaGeneralRequest filtroConsulta)
        {
            RecuadoClient _recuadoClient = new();
            var clientLogin = await _recuadoClient.Login();
            var request = new RestRequest($"/api/{filtroConsulta.ApiServicio}/{filtroConsulta.FechaConsultaConFormato}", Method.Get);
            request.AddHeader("Authorization", $"Bearer {clientLogin.Token}");
            var response = await _recuadoClient._client.ExecuteAsync(request);
            return response?.Content;
        }
    }
}
