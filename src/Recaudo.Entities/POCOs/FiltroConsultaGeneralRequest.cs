namespace Recaudo.Entities.POCOs
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
        public string ApiServicio { get; set; }
    }
}
