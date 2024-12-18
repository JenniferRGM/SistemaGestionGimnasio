using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SistemaGestionGimnasio.Modelos
{
    /// <summary>
    /// Representa una membresía asignada a un usuario dentro del sistema de gestión del gimnasio.
    /// </summary>
    public class Membresia
    {
        public int id { get; set; }
        public int usuarioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Membresia"/>.
        /// </summary>
        /// <param name="id">Identificador único de la membresía.</param>
        /// <param name="usuarioId">Identificador del usuario asociado.</param>
        /// <param name="fechaInicio">Fecha de inicio de la membresía.</param>
        /// <param name="fechaFin">Fecha de finalización de la membresía.</param>
        public Membresia(int id, int usuarioId, DateTime fechaInicio, DateTime fechaFin)
        {
            this.id = id;
            this.usuarioId = usuarioId;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }

    }
}
