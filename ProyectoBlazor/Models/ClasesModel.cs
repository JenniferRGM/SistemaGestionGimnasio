using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBlazor.Modelos
{
    /// <summary>
    /// Representa una clase dentro del sistema de gestión del gimnasio.
    /// </summary>
    public class ClasesModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int EntrenadorId { get; set; }
        public String EntrenadorNombre { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ClasesModel"/>.
        /// </summary>
        /// <param name="id">Identificador único de la clase.</param>
        /// <param name="nombre">Nombre de la clase.</param>
        /// <param name="entrenadorId">Identificador del entrenador asignado.</param>
        /// <param name="entrenadorNombre">Nombre del entrenador asignado.</param>

        public ClasesModel(int Id, string Nombre, int EntrenadorId, string EntrenadorNombre)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.EntrenadorId = EntrenadorId;
            this.EntrenadorNombre = EntrenadorNombre;
        }


    }
}

