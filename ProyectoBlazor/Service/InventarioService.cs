using ProyectoBlazor.Modelos;
using ProyectoBlazor.Repository;
using SistemaGestionGimnasio.Modelos;

namespace ProyectoBlazor.Service
{
    public class InventarioService
    {
        private InventarioRepository inventarioRepository;

        public InventarioService(InventarioRepository inventarioRepository)
        {
            this.inventarioRepository = inventarioRepository;
        }

        public async Task<List<InventarioModel>> ObtenerEquiposCercaDeVencer()
        {
            return await inventarioRepository.ObtenerEquiposProximosAVencer();
        }

    }
}
