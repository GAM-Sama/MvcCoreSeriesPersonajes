using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreSeriesPersonajes.Models
{
    public class Serie
    {
        public int IdSerie { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public float Puntuacion { get; set; }
        public int Year { get; set; }
    }
}
