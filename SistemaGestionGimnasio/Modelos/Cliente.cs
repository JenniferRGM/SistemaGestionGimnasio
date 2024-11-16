using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionGimnasio.Modelos
{
    internal class Cliente : Usuario
    {
        public Cliente(int id, string nombre, string correo, string contraseña)
                    : base(id, nombre, correo, contraseña, "Cliente")
        { 
        }

    }
}
