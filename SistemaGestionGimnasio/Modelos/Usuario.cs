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
        public string Tipo {  get; set; }

        // Nuevos atributos para los entrenadores
        public List<string> Horarios { get; set; }
        public string PuntosFuertes { get; set; }
        public Usuario(int id, string nombre, string correo, string tipo)
        {
            Id = id;
            Nombre = nombre;
            Correo = correo;
            Tipo = tipo;
            Horarios = new List<string>();

        }
    }
}
