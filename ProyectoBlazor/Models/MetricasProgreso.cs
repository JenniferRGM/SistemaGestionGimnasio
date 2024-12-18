using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoBlazor.Models
{
    /// <summary>
    /// Representa las métricas de progreso registradas por un usuario.
    /// </summary>
    public class MetricasProgreso
    {
        public Int32 id { get; set; }
        public Int32 usuario_id { get; set; }
        public DateTime fecha { get; set; }
        public String parte { get; set; }

        public Int32 cantidad { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MetricasProgreso"/>.
        /// </summary>
        /// <param name="id">Identificador único de la métrica.</param>
        /// <param name="usuarioId">Identificador del usuario asociado.</param>
        /// <param name="fecha">Fecha de registro de la métrica.</param>
        /// <param name="parte">Parte o área relacionada.</param>
        /// <param name="cantidad">Cantidad asociada a la métrica.</param>
        public MetricasProgreso(int id, int usuario_id, DateTime fecha, string parte, int cantidad)
        {
            this.id = id;
            this.usuario_id = usuario_id;
            this.fecha = fecha;
            this.parte = parte;
            this.cantidad = cantidad;
        }
    }
}
