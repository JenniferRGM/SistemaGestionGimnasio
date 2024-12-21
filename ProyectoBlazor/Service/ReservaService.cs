using MySql.Data.MySqlClient;
using ProyectoBlazor.Modelos;
using ProyectoBlazor.Repository;
using SistemaGimnasio.Repository;

namespace ProyectoBlazor.Service
{
    /// <summary>
    /// Servicio para gestionar reservas de clases y espacios en el gimnasio.
    /// </summary>
    public class ReservaService
    {
        private ReservaRepository reservaRepository;
        private EspacioRepository espacioRepository;
        

        /// <summary>
        /// Constructor para inicializar el servicio de reservas.
        /// </summary>
        /// <param name="reservaRepository">Instancia del repositorio de reservas.</param>
        public ReservaService(ReservaRepository reservaRepository, EspacioRepository espacioRepository)
        {
            this.reservaRepository = reservaRepository;
            this.espacioRepository = espacioRepository;
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
        public async Task<List<Reservas>> ListarReservasCliente(int clienteId)
        {
            // Obtén la lista de reservas para el cliente
            List<Reservas> reservas = await reservaRepository.ObtenerReservasPorClienteId(clienteId);

            // Itera sobre las reservas y asigna el espacio correspondiente
            foreach (var reserva in reservas)
            {
                var espacio = await espacioRepository.ObtenerEspacioPorId(reserva.ClaseEspacioId);
                reserva.espacio = espacio;
                Console.Write(espacio);
            }

            // Retorna la lista de reservas con los espacios asignados
            return reservas;
        }




    }
}


