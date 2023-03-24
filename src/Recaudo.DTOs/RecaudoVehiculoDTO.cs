namespace Recaudo.DTOs
{
    public class RecaudoVehiculoDTO
    {
        public int Id { get; set; }
        public string Estacion { get; set; }
        public string Sentido { get; set; }
        public int Hora { get; set; }
        public DateTime Fecha { get; set; }
        public string Categoria { get; set; }
        public double ValorTabulado { get; set; }
    }
}
