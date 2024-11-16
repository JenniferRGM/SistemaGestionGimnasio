using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionGimnasio.Modelos
{
    public class Usuario
    {
        public int Id {  get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Tipo {  get; set; }

  
        public Usuario(int id, string nombre, string correo, string tipo, string contraseña)
        {
            Id = id;
            Nombre = nombre;
            Correo = correo;
            Tipo = tipo;
            Contraseña = contraseña;
            

        }
    }
}
