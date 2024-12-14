using ProyectoBlazor.Repository;
using SistemaGestionGimnasio.Modelos;
using SistemaGimnasio.Repository;

namespace ProyectoBlazor.Service
{
    public class ClaseService
    {
        private ClaseRepository claseRepository;

        public ClaseService(ClaseRepository claseRepository)
        {
            this.claseRepository = claseRepository;
        }


        public async Task<List<ClasesModel>> listarClasesPorEntrenador(Int32 EntrenadorId)
        {
            return await claseRepository.ObtenerTodasLasClasesPorEntrenador(EntrenadorId);
        }

        public async Task<List<ClasesModel>> listarClases()
        {
            return await claseRepository.ObtenerTodasLasClases();
        }

        public async Task<ClasesModel> ObtenerClasePorId(Int32 ClaseId)
        {
            return await claseRepository.ObtenerClasePorId(ClaseId);
        }

    }
}
