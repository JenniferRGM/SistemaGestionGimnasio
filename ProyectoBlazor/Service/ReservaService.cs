using ProyectoBlazor.Modelos;
using SistemaGimnasio.Repository;

namespace ProyectoBlazor.Service
{
    /// <summary>
    /// Servicio para gestionar reservas de clases y espacios en el gimnasio.
    /// </summary>
    public class ReservaService
    {
        private ReservaRepository reservaRepository;

        /// <summary>
        /// Constructor para inicializar el servicio de reservas.
        /// </summary>
        /// <param name="reservaRepository">Instancia del repositorio de reservas.</param>
        public ReservaService(ReservaRepository reservaRepository)
        {
            this.reservaRepository = reservaRepository;
        }

        /// <summary>
        /// Registra una nueva reserva para un cliente en un espacio de clase.
        /// </summary>
        /// <param name="ClaseEspacioId">Identificador del espacio de clase.</param>
        /// <param name="ClienteId">Identificador del cliente.</param>
        public async Task RegistrarReserva(Int32 ClaseEspacioId, Int32 ClienteId)
        {
            // Crea la reserva en el repositorio
            await reservaRepository.CrearReserva(ClaseEspacioId, ClienteId);
            // Resta un cupo al espacio correspondiente
            await reservaRepository.RestarCupo(ClaseEspacioId);
        }

        /// <summary>
        /// Lista todas las reservas realizadas por un cliente.
        /// </summary>
        /// <param name="ClienteId">Identificador del cliente.</param>
        /// <returns>Lista de reservas realizadas por el cliente.</returns>
        public async Task<List<Reservas>> ListarReservasCliente(Int32 ClienteId)
        {

            return await reservaRepository.ObtenerReservasPorClienteId(ClienteId);
        }




    }
}


