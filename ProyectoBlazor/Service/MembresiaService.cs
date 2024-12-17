using SistemaGestionGimnasio.Modelos;
using SistemaGimnasio.Repository;

namespace ProyectoBlazor.Service
{
    /// <summary>
    /// Servicio que proporciona operaciones relacionadas con las membresías de los usuarios.
    /// </summary>
    public class MembresiaService
    {
        /// <summary>
        /// Repositorio para acceder a los datos de membresías.
        /// </summary>
        private MembresiaRepository membresiaRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MembresiaService"/>.
        /// </summary>
        /// <param name="membresiaRepository">Instancia del repositorio de membresías.</param>
        public MembresiaService(MembresiaRepository membresiaRepository)
        {
            this.membresiaRepository = membresiaRepository;
        }

        /// <summary>
        /// Obtiene la cantidad de días restantes de una membresía para un usuario específico.
        /// </summary>
        /// <param name="userId">Identificador del usuario.</param>
        /// <returns>
        /// Número de días restantes como un entero o null si el usuario no tiene una membresía activa.
        /// </returns>
        public async Task<int?> ObtenerDiasRestantesMembresia(int userId)
        {
            // Recupera la membresía del usuario desde el repositorio
            Membresia membresia = await membresiaRepository.ObtenerMembresiaPorUsuarioIdAsync(userId);

            // Verifica si no existe membresía
            if (membresia == null)
            {
                return null;// No hay membresía
            }

            // Calcula los días restantes hasta la fecha de vencimiento
            int diasRestantes = (membresia.FechaFin - DateTime.Now).Days;

            return diasRestantes;
        }



    }
}
