using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBlazor.Modelos
{
    /// <summary>
    /// Representa un elemento del inventario dentro del sistema de gestión del gimnasio.
    /// </summary>
    public class InventarioModel
    {
        public string NombreEquipo { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaAdquisicion { get; set; }
        public int VidaUtilDias { get; set; }  // Los años de vida útil
        public string Estado { get; set; }

        public InventarioModel() { }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InventarioModel"/> con valores específicos.
        /// </summary>
        /// <param name="nombreEquipo">Nombre del equipo.</param>
        /// <param name="categoria">Categoría del equipo.</param>
        /// <param name="fechaAdquisicion">Fecha en la que se adquirió el equipo.</param>
        /// <param name="vidaUtilDias">Vida útil en días.</param>
        /// <param name="estado">Estado actual del equipo.</param>
        public InventarioModel(string nombreEquipo, string categoria, DateTime fechaAdquisicion, int VidaUtilDias, string estado)
        {
            NombreEquipo = nombreEquipo;
            Categoria = categoria;
            FechaAdquisicion = fechaAdquisicion;
            this.VidaUtilDias = VidaUtilDias;
            Estado = estado;
        }


    }

}
