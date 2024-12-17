using SistemaGimnasio.Repository;
using System.IO;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace ProyectoBlazor.Service
{
    /// <summary>
    /// Servicio responsable de generar reportes en formato PDF relacionados con matrículas, finanzas y clases.
    /// </summary>
    public class ReporteService
    {
        /// <summary>
        /// Repositorio que proporciona los datos necesarios para los reportes.
        /// </summary>
        private readonly ReporteRepository reporteRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ReporteService"/>.
        /// </summary>
        /// <param name="reporteRepository">Instancia del repositorio de reportes.</param>
        public ReporteService(ReporteRepository reporteRepository)
        {
            this.reporteRepository = reporteRepository;
        }

        /// <summary>
        /// Genera un reporte PDF básico con contenido predefinido.
        /// </summary>
        /// <returns>Array de bytes que representa el PDF generado.</returns>
        public async Task<byte[]> GenerarReportePdf()
        {
            using (var memoryStream = new MemoryStream())
            {
                var writer = new PdfWriter(memoryStream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                // Agrega contenido al PDF
                document.Add(new Paragraph("Reporte Clases Más Atractivas"));
                document.Add(new Paragraph("Fecha: " + DateTime.Now.ToString("yyyy-MM-dd")));
                document.Add(new Paragraph("Aquí va el contenido de tu reporte..."));

                // Finaliza el documento
                document.Close();

                // Retorna los bytes del PDF
                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Genera un reporte PDF sobre el crecimiento de matrículas.
        /// </summary>
        /// <returns>Array de bytes que representa el PDF generado.</returns>
        public async Task<byte[]> GenerarReporteCrecimientoMatriculasPdf()
        {
            // Obtiene los datos del reporte de crecimiento de matrículas
            List<(DateTime Fecha, int NuevasMatriculas, int TotalMatriculas)> reporteCrecimiento = await reporteRepository.ObtenerCrecimientoMatriculasAsync();

            using (var memoryStream = new MemoryStream())
            {
                var writer = new PdfWriter(memoryStream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                // Título del reporte
                document.Add(new Paragraph("Reporte de Crecimiento de Matrículas")
                    .SetFontSize(18));
                document.Add(new Paragraph("Fecha: " + DateTime.Now.ToString("yyyy-MM-dd")));

                // Agrega los datos al documento desde la lista 'reporteCrecimiento'
                foreach (var item in reporteCrecimiento)
                {
                    var paragraph = new Paragraph($"Fecha: {item.Fecha.ToShortDateString()} - Nuevas Matrículas: {item.NuevasMatriculas} - Total Matrículas: {item.TotalMatriculas}");
                    document.Add(paragraph);
                }

                // Finaliza el documento
                document.Close();

                // Retorna los bytes del PDF
                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Genera un reporte PDF sobre el informe contable en un rango de fechas.
        /// </summary>
        /// <param name="inicio">Fecha de inicio del rango.</param>
        /// <param name="fin">Fecha de fin del rango.</param>
        /// <returns>Array de bytes que representa el PDF generado.</returns>
        public async Task<byte[]> GenerarReporteInformeContablePdf(DateTime inicio, DateTime fin)
        {
            using (var memoryStream = new MemoryStream())
            {
                var writer = new PdfWriter(memoryStream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                // Título del reporte
                document.Add(new Paragraph("Reporte de Informe Contable")
                    .SetFontSize(18));
                document.Add(new Paragraph($"Fecha de inicio: {inicio.ToShortDateString()} - Fecha de fin: {fin.ToShortDateString()}"));

                // Obtiene los datos del reporte
                var informeContable = await ObtenerInformeContableAsync(inicio, fin);

                // Agregaa los datos al documento
                foreach (var item in informeContable)
                {
                    var paragraph = new Paragraph($"Fecha: {item.Fecha.ToShortDateString()} - Ingreso: {item.Ingreso:C} - Gasto: {item.Gasto:C}");
                    document.Add(paragraph);
                }

                // Finalizaa el documento
                document.Close();

                // Retorna los bytes del PDF
                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Genera un reporte PDF sobre las clases más atractivas.
        /// </summary>
        /// <returns>Array de bytes que representa el PDF generado.</returns>
        public async Task<byte[]> GenerarReporteClasesMasAtractivasPdf()
        {
            using (var memoryStream = new MemoryStream())
            {
                var writer = new PdfWriter(memoryStream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                // Título del reporte
                document.Add(new Paragraph("Reporte de Clases Más Atractivas")
                    .SetFontSize(18));
                document.Add(new Paragraph("Fecha: " + DateTime.Now.ToString("yyyy-MM-dd")));

                // Obtiene los datos del reporte
                var clasesAtractivas = await ObtenerClasesMasAtractivasAsync();

                // Agregae los datos al documento
                foreach (var item in clasesAtractivas)
                {
                    var paragraph = new Paragraph($"Clase: {item.Clase} - Horario: {item.Horario} - Cupos disponibles: {item.Cupos}");
                    document.Add(paragraph);
                }

                // Finaliza el documento
                document.Close();

                // Retorna los bytes del PDF
                return memoryStream.ToArray();
            }
        }



        /// <summary>
        /// Obtiene los datos del crecimiento de matrículas.
        /// </summary>
        public async Task<List<(DateTime Fecha, int NuevasMatriculas, int TotalMatriculas)>> ObtenerCrecimientoMatriculasAsync()
        {
            return await reporteRepository.ObtenerCrecimientoMatriculasAsync();
        }

        /// <summary>
        /// Obtiene el informe contable en un rango de fechas.
        /// </summary>
        public async Task<List<(DateTime Fecha, Decimal Ingreso, Decimal Gasto)>> ObtenerInformeContableAsync(DateTime inicio, DateTime fin)
        {
            return await reporteRepository.ObtenerInformeContableAsync(inicio, fin);
        }

        /// <summary>
        /// Obtiene las clases más atractivas en función de las reservas.
        /// </summary>
        public async Task<List<(string Clase, string Horario, int Cupos)>> ObtenerClasesMasAtractivasAsync()
        {
            return await reporteRepository.ObtenerClasesMasReservadasAsync();
        }


    }

}
