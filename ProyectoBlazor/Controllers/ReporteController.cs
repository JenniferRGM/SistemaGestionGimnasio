using Microsoft.AspNetCore.Mvc;
using ProyectoBlazor.Service;

namespace ProyectoBlazor.Controllers
{
    [Route("api/reporte")]
    [ApiController]
    public class ReporteController : ControllerBase 
    {
        private readonly ReporteService _reporteService;

        public ReporteController(ReporteService reporteService)
        {
            _reporteService = reporteService;
        }

        [HttpGet("generar-pdf-matriculas")]
        public async Task<IActionResult> GenerarReporteCrecimientoMatriculas()
        {
            var pdfBytes = await _reporteService.GenerarReporteCrecimientoMatriculasPdf();
            return File(pdfBytes, "application/pdf", "reporte_matriculas.pdf");
        }

        [HttpGet("generar-pdf-contable")]
        public async Task<IActionResult> GenerarReporteInformeContable(DateTime inicio, DateTime fin)
        {
            var pdfBytes = await _reporteService.GenerarReporteInformeContablePdf(inicio, fin);
            return File(pdfBytes, "application/pdf", "informe_contable.pdf");
        }

        [HttpGet("generar-pdf-clases")]
        public async Task<IActionResult> GenerarReporteClasesMasAtractivas()
        {
            var pdfBytes = await _reporteService.GenerarReporteClasesMasAtractivasPdf();
            return File(pdfBytes, "application/pdf", "clases_atractivas.pdf");
        }
    }
}
