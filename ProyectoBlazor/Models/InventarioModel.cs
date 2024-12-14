using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBlazor.Modelos
{
    public class InventarioModel
    {
        public string NombreEquipo { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaAdquisicion { get; set; }
        public int VidaUtilDias { get; set; }  // Los años de vida útil
        public string Estado { get; set; }

        public InventarioModel() { }

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
