using ProyectoBlazor.Modelos;
using SistemaGimnasio.Repository;

namespace ProyectoBlazor.Service
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con membresías.
    /// </summary>
    public class MembresiaService
    {
        private MembresiaRepository membresiaRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MembresiaService"/>.
        /// </summary>
        /// <param name="membresiaRepository">Repositorio de membresías.</param>
        public MembresiaService(MembresiaRepository membresiaRepository)
        {
            this.membresiaRepository = membresiaRepository;
        }

        /// <summary>
        /// Crea una nueva membresía para un usuario.
        /// </summary>
        /// <param name="usuarioId">ID del usuario asociado a la membresía.</param>
        /// <param name="fechaInicio">Fecha de inicio de la membresía.</param>
        /// <param name="fechaFin">Fecha de finalización de la membresía.</param>
        public void crearMembresia(Int32 usuarioId, DateOnly fechaInicio, DateOnly fechaFin)
        {
            membresiaRepository.CrearMembresia(usuarioId, fechaInicio, fechaFin);
        }

        /// <summary>
        /// Obtiene los días restantes de una membresía activa para un usuario.
        /// </summary>
        /// <param name="userId">ID del usuario asociado a la membresía.</param>
        /// <returns>Número de días restantes o null si no hay membresía activa.</returns>
        public async Task<int?> ObtenerDiasRestantesMembresia(int userId)
        {
            Membresia membresia = await membresiaRepository.ObtenerMembresiaPorUsuarioIdAsync(userId);

            if (membresia == null)
            {
                return null;// No hay membresía activa
            }
            // Calcula los días restantes
            int diasRestantes = (membresia.FechaFin - DateTime.Now).Days;

            return diasRestantes;
        }

        /// <summary>
        /// Obtiene todas las membresías registradas.
        /// </summary>
        /// <returns>Lista de membresías.</returns>
        public async Task<List<Membresia>> ObtenerTodasLasMembresias()
        {
            List<Membresia> membresias = await membresiaRepository.ObtenerTodasLasMembresiasAsync();

            return membresias;
        }

    }
}
