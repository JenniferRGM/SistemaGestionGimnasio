using ProyectoBlazor.Repository;
using SistemaGestionGimnasio.Modelos;
using SistemaGimnasio.Repository;

namespace ProyectoBlazor.Service
{
    /// <summary>
    /// Servicio que proporciona operaciones relacionadas con las clases.
    /// </summary>
    public class ClaseService
    {
        /// <summary>
        /// Repositorio de clases para acceder a los datos de la base de datos.
        /// </summary>
        private ClaseRepository claseRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ClaseService"/>.
        /// </summary>
        /// <param name="claseRepository">Instancia del repositorio de clases.</param>
        public ClaseService(ClaseRepository claseRepository)
        {
            this.claseRepository = claseRepository;
        }

        /// <summary>
        /// Obtiene una lista de clases asociadas a un entrenador específico.
        /// </summary>
        /// <param name="entrenadorId">Identificador del entrenador.</param>
        /// <returns>Lista de <see cref="ClasesModel"/> asociadas al entrenador.</returns>

        public async Task<List<ClasesModel>> listarClasesPorEntrenador(Int32 EntrenadorId)
        {
            return await claseRepository.ObtenerTodasLasClasesPorEntrenador(EntrenadorId);
        }

        /// <summary>
        /// Obtiene una lista de todas las clases disponibles.
        /// </summary>
        /// <returns>Lista de todas las <see cref="ClasesModel"/>.</returns>
        public async Task<List<ClasesModel>> listarClases()
        {
            return await claseRepository.ObtenerTodasLasClases();
        }

        /// <summary>
        /// Obtiene una clase específica por su identificador.
        /// </summary>
        /// <param name="claseId">Identificador único de la clase.</param>
        /// <returns>Instancia de <see cref="ClasesModel"/> si se encuentra, de lo contrario null.</returns>
        public async Task<ClasesModel> ObtenerClasePorId(Int32 ClaseId)
        {
            return await claseRepository.ObtenerClasePorId(ClaseId);
        }

    }
}
