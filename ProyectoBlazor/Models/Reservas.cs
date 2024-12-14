using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoBlazor.Models;

namespace SistemaGestionGimnasio.Modelos
{
    public class Reservas
    {
        public Int32 Id { get; set; }

        public Int32 ClaseEspacioId { get; set; }
        public Int32 ClienteId { get; set; }

        public EspacioModel espacio { get; set; }



        public Reservas(int id, int claseEspacioId, int clienteId)
        {
            Id = id;
            ClaseEspacioId = claseEspacioId;
            ClienteId = clienteId;
        }

    }
}
