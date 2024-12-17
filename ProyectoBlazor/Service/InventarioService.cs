using ProyectoBlazor.Modelos;
using ProyectoBlazor.Repository;
using SistemaGestionGimnasio.Modelos;

namespace ProyectoBlazor.Service
{
    /// <summary>
    /// Servicio que proporciona operaciones relacionadas con la gestión del inventario.
    /// </summary>
    public class InventarioService
    {
        /// <summary>
        /// Repositorio para acceder a los datos del inventario.
        /// </summary>
        private InventarioRepository inventarioRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InventarioService"/>.
        /// </summary>
        /// <param name="inventarioRepository">Instancia del repositorio del inventario.</param>
        public InventarioService(InventarioRepository inventarioRepository)
        {
            this.inventarioRepository = inventarioRepository;
        }

        // <summary>
        /// Obtiene una lista de equipos cuyo vencimiento está próximo (dentro de los próximos 3 meses).
        /// </summary>
        /// <returns>Lista de <see cref="InventarioModel"/> con los equipos cerca de vencer.</returns>
        public async Task<List<InventarioModel>> ObtenerEquiposCercaDeVencer()
        {
            return await inventarioRepository.ObtenerEquiposProximosAVencer();
        }

    }
}
