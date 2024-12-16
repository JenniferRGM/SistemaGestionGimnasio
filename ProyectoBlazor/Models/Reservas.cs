using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoBlazor.Models;

namespace SistemaGestionGimnasio.Modelos
{
    /// <summary>
    /// Representa una reserva realizada por un cliente para un espacio asociado a una clase.
    /// </summary>
    public class Reservas
    {
        public Int32 Id { get; set; }

        public Int32 ClaseEspacioId { get; set; }
        public Int32 ClienteId { get; set; }

        public EspacioModel espacio { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Reservas"/>.
        /// </summary>
        /// <param name="id">Identificador único de la reserva.</param>
        /// <param name="claseEspacioId">Identificador del espacio asignado a la clase.</param>
        /// <param name="clienteId">Identificador del cliente.</param>

        public Reservas(int id, int claseEspacioId, int clienteId)
        {
            Id = id;
            ClaseEspacioId = claseEspacioId;
            ClienteId = clienteId;
        }

    }
}
