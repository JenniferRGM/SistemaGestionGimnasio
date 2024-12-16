using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBlazor.Modelos
{
    /// <summary>
    /// Representa un cliente que hereda de la clase base <see cref="Usuario"/>.
    /// </summary>
    internal class Cliente : Usuario
    {
        // <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Cliente"/>.
        /// </summary>
        /// <param name="id">Identificador único del cliente.</param>
        /// <param name="nombre">Nombre completo del cliente.</param>
        /// <param name="correo">Correo electrónico del cliente.</param>
        /// <param name="nombreUsuario">Nombre de usuario para acceder al sistema.</param>
        /// <param name="contraseña">Contraseña asociada al cliente.</param>
        public Cliente(int id, string nombre, string correo, string nombreUsuario, string contraseña)
        : base(id, nombre, correo, "Cliente", contraseña, nombreUsuario)
        {
        }

    }
}
