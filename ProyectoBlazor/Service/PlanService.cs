using ProyectoBlazor.Models;
using ProyectoBlazor.Repository;

namespace ProyectoBlazor.Service
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con los planes.
    /// </summary>
    public class PlanService
    {
        private PlanRepository planRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlanService"/>.
        /// </summary>
        /// <param name="planRepository">Repositorio de planes.</param>
        public PlanService(PlanRepository planRepository)
        {
            this.planRepository = planRepository;
        }

        /// <summary>
        /// Obtiene todos los planes disponibles en el sistema.
        /// </summary>
        /// <returns>Una lista de planes.</returns>
        public async Task<List<Plan>> ObtenerTodosLosPlanes()
        {
            return await planRepository.ObtenerTodosLosPlanes();
        }



    }

}
