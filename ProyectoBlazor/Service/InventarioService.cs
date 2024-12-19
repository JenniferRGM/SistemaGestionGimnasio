using ProyectoBlazor.Modelos;
using ProyectoBlazor.Repository;


namespace ProyectoBlazor.Service
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con el inventario.
    /// </summary>
    public class InventarioService
    {
        private InventarioRepository inventarioRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InventarioService"/>.
        /// </summary>
        /// <param name="inventarioRepository">Repositorio de inventario.</param>
        public InventarioService(InventarioRepository inventarioRepository)
        {
            this.inventarioRepository = inventarioRepository;
        }

        /// <summary>
        /// Obtiene una lista de equipos próximos a vencer (dentro de los próximos 3 meses).
        /// </summary>
        /// <returns>Lista de <see cref="InventarioModel"/> con equipos próximos a vencer.</returns>
        public async Task<List<InventarioModel>> ObtenerEquiposCercaDeVencer()
        {
            return await inventarioRepository.ObtenerEquiposProximosAVencer();
        }

        /// <summary>
        /// Obtiene todos los equipos próximos a vencer.
        /// </summary>
        /// <returns>Lista de <see cref="InventarioModel"/> con los equipos próximos a vencer.</returns>
        public async Task<List<InventarioModel>> ObtenerEquiposProximosAVencer()
        {
            return await inventarioRepository.ObtenerEquiposProximosAVencer();
        }

        /// <summary>
        /// Obtiene todos los equipos registrados en el inventario.
        /// </summary>
        /// <returns>Lista de <see cref="InventarioModel"/> con todos los equipos.</returns>
        public async Task<List<InventarioModel>> ObtenerTodosLosEquipos()
        {
            return await inventarioRepository.ObtenerTodosLosEquipos();
        }

        /// <summary>
        /// Obtiene un equipo específico por su identificador.
        /// </summary>
        /// <param name="id">Identificador del equipo.</param>
        /// <returns>Instancia de <see cref="InventarioModel"/> si se encuentra, de lo contrario null.</returns>
        public async Task<InventarioModel> ObtenerEquipoPorId(int id)
        {
            return await inventarioRepository.ObtenerEquipoPorId(id);
        }

        /// <summary>
        /// Crea un nuevo equipo en el inventario.
        /// </summary>
        /// <param name="nuevoEquipo">Datos del nuevo equipo a crear.</param>
        /// <returns>Identificador del equipo creado.</returns>
        public async Task<int> CrearEquipo(InventarioModel nuevoEquipo)
        {
            return await inventarioRepository.CrearEquipo(nuevoEquipo);
        }

        /// <summary>
        /// Actualiza los datos de un equipo existente en el inventario.
        /// </summary>
        /// <param name="id">Identificador del equipo a actualizar.</param>
        /// <param name="equipoActualizado">Datos actualizados del equipo.</param>
        /// <returns>True si la actualización fue exitosa, de lo contrario False.</returns>
        public async Task<bool> ActualizarEquipo(int id, InventarioModel equipoActualizado)
        {
            return await inventarioRepository.ActualizarEquipo(id, equipoActualizado);
        }

        /// <summary>
        /// Elimina un equipo del inventario.
        /// </summary>
        /// <param name="id">Identificador del equipo a eliminar.</param>
        /// <returns>True si la eliminación fue exitosa, de lo contrario False.</returns>
        public async Task<bool> EliminarEquipo(int id)
        {
            return await inventarioRepository.EliminarEquipo(id);
        }

    }
}
