using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionGimnasio.Modelos
{
    internal class Inventario
    {
        public string NombreEquipo { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaAdquisicion { get; set; }
        public string VidaUtilEstimada { get; set; } 
        public string Estado { get; set; }

        public Inventario() { }

        public Inventario(string nombreEquipo, string categoria, DateTime fechaAdquisicion, string vidaUtilEstimada, string estado)
        {
            NombreEquipo = nombreEquipo;
            Categoria = categoria;
            FechaAdquisicion = fechaAdquisicion;
            VidaUtilEstimada = vidaUtilEstimada;
            Estado = estado;
        }

        public bool VerificarFinDeVidaUtil()
        {
            // Asumiendo que "VidaUtilEstimada" está en años.
            if (int.TryParse(VidaUtilEstimada.Split(' ')[0], out int vidaUtilEnAnios))
            {
                DateTime fechaFinVida = FechaAdquisicion.AddYears(vidaUtilEnAnios);
                return DateTime.Now > fechaFinVida;
            }

            return false;
        }
    }


}
