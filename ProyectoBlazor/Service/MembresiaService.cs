using SistemaGestionGimnasio.Modelos;
using SistemaGimnasio.Repository;

namespace ProyectoBlazor.Service
{
    public class MembresiaService
    {
        private MembresiaRepository membresiaRepository;

        public MembresiaService(MembresiaRepository membresiaRepository)
        {
            this.membresiaRepository = membresiaRepository;
        }

        public async Task<int?> ObtenerDiasRestantesMembresia(int userId)
        {
            Membresia membresia = await membresiaRepository.ObtenerMembresiaPorUsuarioIdAsync(userId);

            if (membresia == null)
            {
                return null;
            }

            int diasRestantes = (membresia.FechaFin - DateTime.Now).Days;

            return diasRestantes;
        }



    }
}
