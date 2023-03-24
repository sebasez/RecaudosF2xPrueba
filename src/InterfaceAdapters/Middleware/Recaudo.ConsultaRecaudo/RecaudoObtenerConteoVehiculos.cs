using Recaudo.ConsultaRecaudo.Entities;
using RestSharp;

namespace Recaudo.ConsultaRecaudo
{
    public class RecaudoObtenerConteoVehiculos
    {
        public async Task<object> ObtenerConteo(FiltroConsultaGeneralRequest filtroConsulta)
        {
            RecuadoClient _recuadoClient = new();
            var clientLogin = await _recuadoClient.Login();
            var request = new RestRequest($"/api/ConteoVehiculos/{filtroConsulta.FechaConsultaConFormato}", Method.Get);
            request.AddHeader("Authorization", $"Bearer {clientLogin.Token}");
            return _recuadoClient._client.ExecuteAsync(request);
        }
    }
}
