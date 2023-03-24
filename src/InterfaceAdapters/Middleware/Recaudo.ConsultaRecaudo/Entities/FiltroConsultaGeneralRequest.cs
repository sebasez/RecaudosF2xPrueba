namespace Recaudo.ConsultaRecaudo.Entities
{
    public class FiltroConsultaGeneralRequest
    {
        public DateTime FechaConsulta { private get; set; }
        public string FechaConsultaConFormato
        {
            get
            {
                return FechaConsulta.ToString("yyyy-MM-dd");
            }
        }
    }
}
