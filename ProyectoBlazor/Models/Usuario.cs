using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBlazor.Modelos
{
    /// <summary>
    /// Representa un usuario dentro del sistema.
    /// </summary>
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Tipo { get; set; }
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Usuario"/>.
        /// </summary>
        public Usuario()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Usuario"/> con correo y contraseña.
        /// </summary>
        /// <param name="correo">Correo electrónico del usuario.</param>
        /// <param name="contraseña">Contraseña del usuario.</param>
        public Usuario(string correo, string contraseña)
        {
            Correo = correo;
            Contraseña = contraseña;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Usuario"/> con todos los parámetros.
        /// </summary>
        /// <param name="id">Identificador único del usuario.</param>
        /// <param name="nombre">Nombre completo del usuario.</param>
        /// <param name="correo">Correo electrónico del usuario.</param>
        /// <param name="tipo">Tipo de usuario.</param>
        /// <param name="nombreUsuario">Nombre de usuario para inicio de sesión.</param>
        /// <param name="contraseña">Contraseña del usuario.</param>
        public Usuario(int id, string nombre, string correo, string tipo, string nombreUsuario, string contraseña)
        {
            Id = id;
            Nombre = nombre;
            Correo = correo;
            Tipo = tipo;
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
        }
    }
}
