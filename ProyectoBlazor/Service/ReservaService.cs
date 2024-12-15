using SistemaGestionGimnasio.Modelos;
using SistemaGimnasio.Repository;

namespace ProyectoBlazor.Service
{
    public class ReservaService
    {
        private ReservaRepository reservaRepository;

        public ReservaService(ReservaRepository reservaRepository)
        {
            this.reservaRepository = reservaRepository;
        }


        public async Task RegistrarReserva(Int32 ClaseEspacioId, Int32 ClienteId)
        {
            await reservaRepository.CrearReserva(ClaseEspacioId, ClienteId);

            await reservaRepository.RestarCupo(ClaseEspacioId);
        }

        public async Task<List<Reservas>> ListarReservasCliente(Int32 ClienteId)
        {

            return await reservaRepository.ObtenerReservasPorClienteId(ClienteId);
        }




    }
}

