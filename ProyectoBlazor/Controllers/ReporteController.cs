using Microsoft.AspNetCore.Mvc;
using ProyectoBlazor.Service;

namespace ProyectoBlazor.Controllers
{
    /// <summary>
    /// Controlador para la generación de reportes en formato PDF.
    /// </summary>
    [Route("api/reporte")]
    [ApiController]
    public class ReporteController : ControllerBase 
    {
        private readonly ReporteService _reporteService;

        /// <summary>
        /// Inicializa una nueva instancia del <see cref="ReporteController"/>.
        /// </summary>
        /// <param name="reporteService">Servicio encargado de generar reportes.</param>
        public ReporteController(ReporteService reporteService)
        {
            _reporteService = reporteService;
        }

        /// <summary>
        /// Genera un reporte en PDF del crecimiento de matrículas.
        /// </summary>
        /// <returns>Un archivo PDF con el reporte.</returns>

        [HttpGet("generar-pdf-matriculas")]
        public async Task<IActionResult> GenerarReporteCrecimientoMatriculas()
        {
            var pdfBytes = await _reporteService.GenerarReporteCrecimientoMatriculasPdf();

            // Devuelve el archivo PDF con el nombre "reporte_matriculas.pdf"
            return File(pdfBytes, "application/pdf", "reporte_matriculas.pdf");
        }

        /// <summary>
        /// Genera un informe contable en PDF dentro de un rango de fechas.
        /// </summary>
        /// <param name="inicio">Fecha de inicio del informe.</param>
        /// <param name="fin">Fecha de finalización del informe.</param>
        /// <returns>Un archivo PDF con el informe contable.</returns>
        [HttpGet("generar-pdf-contable")]
        public async Task<IActionResult> GenerarReporteInformeContable(DateTime inicio, DateTime fin)
        {
            var pdfBytes = await _reporteService.GenerarReporteInformeContablePdf(inicio, fin);

            // Devuelve el archivo PDF con el nombre "informe_contable.pdf"
            return File(pdfBytes, "application/pdf", "informe_contable.pdf");
        }

        /// <summary>
        /// Genera un reporte en PDF de las clases más atractivas del gimnasio.
        /// </summary>
        /// <returns>Un archivo PDF con el reporte de clases más atractivas.</returns>
        [HttpGet("generar-pdf-clases")]
        public async Task<IActionResult> GenerarReporteClasesMasAtractivas()
        {
            var pdfBytes = await _reporteService.GenerarReporteClasesMasAtractivasPdf();

            // Devuelve el archivo PDF con el nombre "clases_atractivas.pdf"
            return File(pdfBytes, "application/pdf", "clases_atractivas.pdf");
        }

        [HttpGet("generar-pdf-factura")]
        public async Task<IActionResult> GenerarReporteInformeContable([FromQuery] string facturaId)
        {
            var pdfBytes = await _reporteService.GenerarReporteFactura(int.Parse(facturaId));
            return File(pdfBytes, "application/pdf", "factura_pdf_" + facturaId + ".pdf");
        }
    }
}
