using ProyectoBlazor.Modelos;
using ProyectoBlazor.Models;
using ProyectoBlazor.Repository;
using SistemaGimnasio.Repository;

namespace ProyectoBlazor.Service
{
    public class MetricasProgresoService
    {

        private MetricasProgresoRepository metricasProgresoRepository;

        public MetricasProgresoService(MetricasProgresoRepository metricasProgresoRepository)
        {
            this.metricasProgresoRepository = metricasProgresoRepository;
        }

        public async Task<List<MetricasProgreso>> ObtenerMetricasProgresoPorUsuarioId(Int32 usuarioId)
        {
            return await metricasProgresoRepository.ObtenerMetricasPorUsuarioId(usuarioId);
        }

        public void CrearMetricaProgreso(Int32 usuarioId, String parte, Int32 cantidad, DateTime fecha)
        {
            metricasProgresoRepository.CrearMetricaProgreso(usuarioId, parte, cantidad, fecha);
            return;
        }





    }
}
