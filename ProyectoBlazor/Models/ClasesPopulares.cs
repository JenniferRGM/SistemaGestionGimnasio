using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBlazor.Modelos
{
    /// <summary>
    /// Representa información sobre las clases más populares del gimnasio.
    /// </summary>
    internal class ClasesPopulares
    {
        public string Nombre { get; set; }
        public int Asistentes { get; set; }
        public string Horario { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ClasesPopulares"/>.
        /// </summary>
        /// <param name="nombre">Nombre de la clase.</param>
        /// <param name="asistentes">Número de asistentes a la clase.</param>
        /// <param name="horario">Horario de la clase.</param>
        public ClasesPopulares(string nombre, int asistentes, string horario)
        {
            Nombre = nombre;
            Asistentes = asistentes;
            Horario = horario;
        }

    }
}
