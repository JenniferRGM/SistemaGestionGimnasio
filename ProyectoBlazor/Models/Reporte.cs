using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionGimnasio.Modelos
{
    internal class Reporte
    {
        public DateTime Fecha { get; set; }
        public int CantidadMembresias { get; set; }

        public Reporte(DateTime fecha, int cantidadMembresias)
        {
            Fecha = fecha;
            CantidadMembresias = cantidadMembresias;
        }
    }
}
