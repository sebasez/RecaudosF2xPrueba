﻿namespace Recaudo.DTOs
{
    public class AddConteoVehiculoDTO
    {
        public string Estacion { get; set; }
        public string Sentido { get; set; }
        public int Hora { get; set; }
        public DateTime Fecha { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
    }
}
