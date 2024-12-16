using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBlazor.Modelos
{
    /// <summary>
    /// Representa a un entrenador dentro del sistema, heredando de la clase base <see cref="Usuario"/>.
    /// </summary>
    public class Entrenador : Usuario
    {
        public string PuntosFuertes { get; set; }
        public List<string> Horarios { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Entrenador"/>.
        /// </summary>
        /// <param name="id">Identificador único del entrenador.</param>
        /// <param name="nombre">Nombre completo del entrenador.</param>
        /// <param name="correo">Correo electrónico del entrenador.</param>
        /// <param name="nombreUsuario">Nombre de usuario para acceder al sistema.</param>
        /// <param name="contraseña">Contraseña del entrenador.</param>
        /// <param name="puntosFuertes">Puntos fuertes o habilidades del entrenador.</param>
        public Entrenador(int id, string nombre, string correo, string nombreUsuario, string contraseña, string puntosFuertes)
        : base(id, nombre, correo, "Entrenador", contraseña, nombreUsuario)
        {
            PuntosFuertes = puntosFuertes;
            Horarios = new List<string>();
        }
    }
}
