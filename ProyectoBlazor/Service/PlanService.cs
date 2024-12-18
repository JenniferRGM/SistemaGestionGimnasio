using ProyectoBlazor.Models;
using ProyectoBlazor.Repository;

namespace ProyectoBlazor.Service
{
    public class PlanService
    {
        private PlanRepository planRepository;

        public PlanService(PlanRepository planRepository)
        {
            this.planRepository = planRepository;
        }

        public async Task<List<Plan>> ObtenerTodosLosPlanes()
        {
            return await planRepository.ObtenerTodosLosPlanes();
        }



    }

}
