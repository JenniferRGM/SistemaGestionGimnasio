using MySql.Data.MySqlClient;
using ProyectoBlazor.Modelos;
using ProyectoBlazor.Models;
using ProyectoBlazor.Repository;


namespace ProyectoBlazor.Service
{
    /// <summary>
    /// Servicio para gestionar las operaciones relacionadas con los espacios.
    /// </summary>
    public class EspacioService
    {
        /// <summary>
        /// Repositorio para acceder a los datos de los espacios.
        /// </summary>
        private EspacioRepository espacioRepository;

        /// <summary>
        /// Servicio para gestionar las operaciones relacionadas con las clases.
        /// </summary>
        private ClaseService claseService;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="EspacioService"/>.
        /// </summary>
        /// <param name="espacioRepository">Repositorio de espacios.</param>
        /// <param name="claseService">Servicio de clases.</param>
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
        /// Lista los espacios asociados a un entrenador específico.
        /// </summary>
        /// <param name="entrenadorId">Identificador del entrenador.</param>
        /// <returns>Lista de espacios asociados al entrenador.</returns>
        public async Task<List<EspacioModel>> ListarEspaciosEntrenador(int entrenadorId)
        {
            List<ClasesModel> clases = await claseService.listarClasesPorEntrenador(entrenadorId);

            List<EspacioModel> espacios = new List<EspacioModel>();

            foreach (ClasesModel clasesModel in clases)
            {
                List<EspacioModel> espacios1 = await espacioRepository.ListarEspaciosPorClaseId(clasesModel.Id);

                espacios.AddRange(espacios1);
            }

            return espacios;
        }
        /// <summary>
        /// Lista los espacios asociados a una clase específica.
        /// </summary>
        /// <param name="claseId">Identificador de la clase.</param>
        /// <returns>Lista de espacios de la clase.</returns>
        public async Task<List<EspacioModel>> ListarEspaciosPorClaseId(int ClaseId)
        {
            List<EspacioModel> espacios = await espacioRepository.ListarEspaciosPorClaseId(ClaseId);
            return espacios;
        }

        /// <summary>
        /// Obtiene un espacio específico por su identificador único.
        /// </summary>
        /// <param name="espacioId">Identificador del espacio.</param>
        /// <returns>Instancia de <see cref="EspacioModel"/> si se encuentra, de lo contrario null.</returns>
        public async Task<EspacioModel> ObtenerEspacioPorId(int EspacioId)
        {
            return await espacioRepository.ObtenerEspacioPorId(EspacioId);
        }

        /// <summary>
        /// Obtiene la lista de personas en un espacio específico.
        /// </summary>
        /// <param name="espacioId">Identificador del espacio.</param>
        /// <returns>Lista de personas presentes en el espacio.</returns>
        public async Task<List<Usuario>> ObtenerPersonasEnEspacioPorEspacioId(int EspacioId)
        {
            return await espacioRepository.ConsultarPersonasEnEspacioPorEspacioId(EspacioId);
        }


    }


}

