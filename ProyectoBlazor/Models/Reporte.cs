using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionGimnasio.Modelos
{
    /// <summary>
    /// Representa un reporte que contiene información sobre las membresías en una fecha específica.
    /// </summary>
    internal class Reporte
    {
        public DateTime Fecha { get; set; }
        public int CantidadMembresias { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Reporte"/>.
        /// </summary>
        /// <param name="fecha">Fecha en la que se genera el reporte.</param>
        /// <param name="cantidadMembresias">Cantidad total de membresías registradas.</param>
        public Reporte(DateTime fecha, int cantidadMembresias)
        {
            Fecha = fecha;
            CantidadMembresias = cantidadMembresias;
        }
    }
}
