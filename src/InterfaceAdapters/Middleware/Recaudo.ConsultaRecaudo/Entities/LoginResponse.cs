namespace Recaudo.ConsultaRecaudo.Entities
{
    public class LoginResponse
    {
        public DateTime Expiration { get; set; }
        public string? Token { get; set; }
    }
}
