using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionGimnasio.Modelos
{
    internal class Entrenador : Usuario
    {
        public string PuntosFuertes { get; set; }
        public List<string> Horarios { get; set; }

        public Entrenador(int id, string nombre, string correo, string nombreUsuario, string contraseña, string puntosFuertes)
        : base(id, nombre, correo, "Entrenador", contraseña, nombreUsuario)
        {
            PuntosFuertes = puntosFuertes;
            Horarios = new List<string>();
        }
    }
}
