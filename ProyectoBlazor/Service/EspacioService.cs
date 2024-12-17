using MySql.Data.MySqlClient;
using ProyectoBlazor.Modelos;
using ProyectoBlazor.Models;
using ProyectoBlazor.Repository;
using SistemaGestionGimnasio.Modelos;

namespace ProyectoBlazor.Service
{
    /// <summary>
    /// Servicio responsable de manejar operaciones relacionadas con espacios y clases.
    /// </summary>
    public class EspacioService
    {
        /// <summary>
        /// Repositorio para acceder a los datos de espacios.
        /// </summary>
        private EspacioRepository espacioRepository;

        /// <summary>
        /// Servicio para acceder a los datos de clases.
        /// </summary>
        private ClaseService claseService;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="EspacioService"/>.
        /// </summary>
        /// <param name="espacioRepository">Instancia del repositorio de espacios.</param>
        /// <param name="claseService">Instancia del servicio de clases.</param>
        public EspacioService(EspacioRepository espacioRepository, ClaseService claseService)
        {
            this.espacioRepository = espacioRepository;
            this.claseService = claseService;
        }

        /// <summary>
        /// Crea un nuevo espacio para una clase específica.
        /// </summary>
        /// <param name="claseId">Identificador de la clase.</param>
        /// <param name="fecha">Fecha del espacio.</param>
        /// <param name="cupos">Cantidad de cupos disponibles.</param>
        public async Task CrearEspacio(int claseId, DateTime fecha, int Cupos)
        {
            await espacioRepository.CrearEspacio(claseId, fecha, Cupos);
            return;
        }

        /// <summary>
        /// Lista todos los espacios asociados a las clases de un entrenador específico.
        /// </summary>
        /// <param name="entrenadorId">Identificador del entrenador.</param>
        /// <returns>Lista de <see cref="EspacioModel"/>.</returns>

        public async Task<List<EspacioModel>> ListarEspaciosEntrenador(int entrenadorId)
        {
            // Obtiene todas las clases del entrenador
            List<ClasesModel> clases = await claseService.listarClasesPorEntrenador(entrenadorId);

            List<EspacioModel> espacios = new List<EspacioModel>();

            // Por cada clase, obtiene los espacios asociados
            foreach (ClasesModel clasesModel in clases)
            {
                List<EspacioModel> espacios1 = await espacioRepository.ListarEspaciosPorClaseId(clasesModel.Id);

                espacios.AddRange(espacios1);
            }

            return espacios;
        }

        // <summary>
        /// Lista los espacios disponibles para una clase específica.
        /// </summary>
        /// <param name="claseId">Identificador de la clase.</param>
        /// <returns>Lista de <see cref="EspacioModel"/>.</returns>
        public async Task<List<EspacioModel>> ListarEspaciosPorClaseId(int ClaseId)
        {
            List<EspacioModel> espacios = await espacioRepository.ListarEspaciosPorClaseId(ClaseId);
            return espacios;
        }

        /// <summary>
        /// Obtiene los detalles de un espacio específico por su identificador.
        /// </summary>
        /// <param name="espacioId">Identificador del espacio.</param>
        /// <returns>Instancia de <see cref="EspacioModel"/>.</returns>
        public async Task<EspacioModel> ObtenerEspacioPorId(int EspacioId)
        {
            return await espacioRepository.ObtenerEspacioPorId(EspacioId);
        }

        /// <summary>
        /// Obtiene una lista de usuarios (personas) asociados a un espacio específico.
        /// </summary>
        /// <param name="espacioId">Identificador del espacio.</param>
        /// <returns>Lista de <see cref="Usuario"/> asociados al espacio.</returns>
        public async Task<List<Usuario>> ObtenerPersonasEnEspacioPorEspacioId(int EspacioId)
        {
            return await espacioRepository.ConsultarPersonasEnEspacioPorEspacioId(EspacioId);
        }


    }


}
