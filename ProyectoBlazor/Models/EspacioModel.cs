using SistemaGestionGimnasio.Modelos;

namespace ProyectoBlazor.Models
{
    /// <summary>
    /// Representa un espacio asignado a una clase dentro del sistema de gestión del gimnasio.
    /// </summary>
    public class EspacioModel
    {
        public Int32 id { get; set; }
        public Int32 claseId { get; set; }

        public String claseNombre { get; set; }

        public DateTime fecha { get; set; }

        public Int32 Cupos { get; set; }

        public ClasesModel clase { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="EspacioModel"/>.
        /// </summary>
        /// <param name="id">Identificador único del espacio.</param>
        /// <param name="claseId">Identificador de la clase asociada.</param>
        /// <param name="fecha">Fecha asignada al espacio.</param>
        /// <param name="claseNombre">Nombre de la clase asociada.</param>
        /// <param name="cupos">Número de cupos disponibles.</param>
        public EspacioModel(int id, int claseId, DateTime fecha, String claseNombre, int cupos)
        {
            this.claseNombre = claseNombre;
            this.id = id;
            this.claseId = claseId;
            this.fecha = fecha;
            this.Cupos = cupos;
        }
    }
}

