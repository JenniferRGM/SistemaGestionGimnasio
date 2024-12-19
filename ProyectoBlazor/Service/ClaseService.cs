using ProyectoBlazor.Repository;
using ProyectoBlazor.Modelos;


namespace ProyectoBlazor.Service
{
    /// <summary>
    /// Servicio para gestionar las operaciones relacionadas con las clases.
    /// </summary>
    public class ClaseService
    {
        /// <summary>
        /// Repositorio para acceder a los datos de las clases.
        /// </summary>
        private ClaseRepository claseRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ClaseService"/>.
        /// </summary>
        /// <param name="claseRepository">Repositorio de clases.</param>
        public ClaseService(ClaseRepository claseRepository)
        {
            this.claseRepository = claseRepository;
        }

        /// <summary>
        /// Obtiene todas las clases asignadas a un entrenador específico.
        /// </summary>
        /// <param name="entrenadorId">Identificador único del entrenador.</param>
        /// <returns>Lista de clases asociadas al entrenador.</returns>
        public async Task<List<ClasesModel>> listarClasesPorEntrenador(Int32 EntrenadorId)
        {
            return await claseRepository.ObtenerTodasLasClasesPorEntrenador(EntrenadorId);
        }

        /// <summary>
        /// Obtiene todas las clases disponibles.
        /// </summary>
        /// <returns>Lista de todas las clases.</returns>
        public async Task<List<ClasesModel>> listarClases()
        {
            return await claseRepository.ObtenerTodasLasClases();
        }

        /// <summary>
        /// Obtiene una clase específica por su identificador único.
        /// </summary>
        /// <param name="claseId">Identificador único de la clase.</param>
        /// <returns>Instancia de <see cref="ClasesModel"/> si se encuentra, de lo contrario null.</returns>
        public async Task<ClasesModel> ObtenerClasePorId(Int32 ClaseId)
        {
            return await claseRepository.ObtenerClasePorId(ClaseId);
        }

    }
}
