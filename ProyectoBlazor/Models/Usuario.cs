using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBlazor.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Tipo { get; set; }
        public string NombreUsuario { get; set; }

        public Usuario()
        {
        }

        public Usuario(string correo, string contraseña)
        {
            Correo = correo;
            Contraseña = contraseña;
        }

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
