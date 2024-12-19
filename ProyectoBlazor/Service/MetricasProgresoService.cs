using ProyectoBlazor.Modelos;
using ProyectoBlazor.Models;
using ProyectoBlazor.Repository;
using SistemaGimnasio.Repository;

namespace ProyectoBlazor.Service
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con las métricas de progreso de los usuarios.
    /// </summary>
    public class MetricasProgresoService
    {

        private MetricasProgresoRepository metricasProgresoRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MetricasProgresoService"/>.
        /// </summary>
        /// <param name="metricasProgresoRepository">Repositorio de métricas de progreso.</param>
        public MetricasProgresoService(MetricasProgresoRepository metricasProgresoRepository)
        {
            this.metricasProgresoRepository = metricasProgresoRepository;
        }

        /// <summary>
        /// Obtiene las métricas de progreso de un usuario específico.
        /// </summary>
        /// <param name="usuarioId">ID del usuario.</param>
        /// <returns>Lista de métricas de progreso asociadas al usuario.</returns>
        public async Task<List<MetricasProgreso>> ObtenerMetricasProgresoPorUsuarioId(Int32 usuarioId)
        {
            return await metricasProgresoRepository.ObtenerMetricasPorUsuarioId(usuarioId);
        }

        /// <summary>
        /// Crea una nueva métrica de progreso para un usuario.
        /// </summary>
        /// <param name="usuarioId">ID del usuario.</param>
        /// <param name="parte">Parte del cuerpo o área relacionada con la métrica.</param>
        /// <param name="cantidad">Cantidad asociada al progreso.</param>
        /// <param name="fecha">Fecha de registro de la métrica.</param>
        public void CrearMetricaProgreso(Int32 usuarioId, String parte, Int32 cantidad, DateTime fecha)
        {
            metricasProgresoRepository.CrearMetricaProgreso(usuarioId, parte, cantidad, fecha);
            return;
        }

        public async Task ObtenerMetricasPorUsuarioId(int usuarioId)
        {
            throw new NotImplementedException();
        }
    }
}
