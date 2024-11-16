using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionGimnasio.Modelos
{
    public class Clases
    {
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public int CupoTotal { get; set; }
        public int CuposDisponibles { get; set; }

        public Clases(string nombre, DateTime fecha, int cupoTotal)
        {
            Nombre = nombre;
            Fecha = fecha;
            CupoTotal = cupoTotal;
            CuposDisponibles = cupoTotal;
        }
    }
}
