using Recaudo.ConsultaRecaudo.Entities;
using RestSharp;

namespace Recaudo.ConsultaRecaudo
{
    public class RecaudoObtenerRecaudoVehiculos
    {
        public async Task<object> ObtenerRecaudo(FiltroConsultaGeneralRequest filtroConsulta)
        {
            RecuadoClient _recuadoClient = new();
            var clientLogin = await _recuadoClient.Login();
            var request = new RestRequest($"/api/RecaudoVehiculos/{filtroConsulta.FechaConsultaConFormato}", Method.Get);
            request.AddHeader("Authorization", $"Bearer {clientLogin.Token}");
            var test = _recuadoClient._client.ExecuteAsync(request);
            return _recuadoClient._client.ExecuteAsync(request);
        }
    }
}
