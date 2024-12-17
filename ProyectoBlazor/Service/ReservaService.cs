using SistemaGestionGimnasio.Modelos;
using SistemaGimnasio.Repository;

namespace ProyectoBlazor.Service
{
    /// <summary>
    /// Servicio que proporciona operaciones relacionadas con las reservas de espacios y clases.
    /// </summary>
    public class ReservaService
    {
        /// <summary>
        /// Repositorio para acceder a los datos de reservas.
        /// </summary>
        private ReservaRepository reservaRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ReservaService"/>.
        /// </summary>
        /// <param name="reservaRepository">Instancia del repositorio de reservas.</param>
        public ReservaService(ReservaRepository reservaRepository)
        {
            this.reservaRepository = reservaRepository;
        }

        /// <summary>
        /// Registra una nueva reserva y actualiza el cupo disponible en el espacio de clase.
        /// </summary>
        /// <param name="claseEspacioId">Identificador del espacio de clase.</param>
        /// <param name="clienteId">Identificador del cliente que realiza la reserva.</param>
        public async Task RegistrarReserva(Int32 ClaseEspacioId, Int32 ClienteId)
        {
            // Crea la reserva en la base de datos
            await reservaRepository.CrearReserva(ClaseEspacioId, ClienteId);

            // Resta un cupo disponible en el espacio de clase
            await reservaRepository.RestarCupo(ClaseEspacioId);
        }

        /// <summary>
        /// Obtiene una lista de reservas realizadas por un cliente específico.
        /// </summary>
        /// <param name="clienteId">Identificador del cliente.</param>
        /// <returns>Lista de <see cref="Reservas"/> asociadas al cliente.</returns>
        public async Task<List<Reservas>> ListarReservasCliente(Int32 ClienteId)
        {

            return await reservaRepository.ObtenerReservasPorClienteId(ClienteId);
        }




    }
}

