using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBlazor.Modelos
{
    internal class Cliente : Usuario
    {
        public Cliente(int id, string nombre, string correo, string nombreUsuario, string contraseña)
        : base(id, nombre, correo, "Cliente", contraseña, nombreUsuario)
        {
        }

    }
}
