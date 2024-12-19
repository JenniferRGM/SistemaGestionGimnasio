using SistemaGimnasio.Repository;
using System.IO;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using ProyectoBlazor.Modelos;


namespace ProyectoBlazor.Service
{
    /// <summary>
    /// Servicio para la generación de reportes en formato PDF.
    /// </summary>
    public class ReporteService
    {
        private readonly ReporteRepository reporteRepository;
        private FacturacionService facturacionService;

        /// <summary>
        /// Constructor para inicializar dependencias del servicio de reportes.
        /// </summary>
        /// <param name="reporteRepository">Repositorio de reportes.</param>
        /// <param name="facturacionService">Servicio de facturación.</param>
        public ReporteService(ReporteRepository reporteRepository, FacturacionService facturacionService)
        {
            this.reporteRepository = reporteRepository;
            this.facturacionService = facturacionService;
        }

        /// <summary>
        /// Genera un PDF básico de ejemplo.
        /// </summary>
        /// <returns>Array de bytes representando el PDF.</returns>
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
        /// Genera un reporte en PDF del crecimiento de matrículas.
        /// </summary>
        /// <returns>Array de bytes representando el PDF.</returns>
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
        /// Genera un reporte contable en PDF dentro de un rango de fechas.
        /// </summary>
        /// <param name="inicio">Fecha de inicio del reporte.</param>
        /// <param name="fin">Fecha de fin del reporte.</param>
        /// <returns>Array de bytes representando el PDF.</returns>
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

                // Agrega los datos al documento
                foreach (var item in informeContable)
                {
                    var paragraph = new Paragraph($"Fecha: {item.Fecha.ToShortDateString()} - Ingreso: {item.Ingreso:C} - Gasto: {item.Gasto:C}");
                    document.Add(paragraph);
                }

                // Finaliza el documento
                document.Close();

                // Retorna los bytes del PDF
                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Genera un reporte en PDF de las clases más atractivas.
        /// </summary>
        /// <returns>Array de bytes representando el PDF.</returns>
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

                // Agrega los datos al documento
                foreach (var item in clasesAtractivas)
                {
                    var paragraph = new Paragraph($"Clase: {item.Clase} - Horario: {item.Horario} - Cupos disponibles: {item.Cupos}");
                    document.Add(paragraph);
                }

                // Finaliza el documento
                document.Close();

                // Retornar los bytes del PDF
                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Genera un PDF con los detalles de una factura.
        /// </summary>
        /// <param name="facturaId">Identificador único de la factura.</param>
        /// <returns>Array de bytes representando el PDF.</returns>
        public async Task<byte[]> GenerarReporteFactura(int facturaId)
        {
            // Obtiene la factura por su ID
            Factura factura = await facturacionService.ObtenerFacturaPorIdAsync(facturaId);

            // Crea un MemoryStream para el reporte
            using (var memoryStream = new MemoryStream())
            {
                // Crea el escritor y el documento PDF
                var writer = new PdfWriter(memoryStream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                // Título del reporte
                document.Add(new Paragraph("Factura No. " + factura.NumeroFactura)
                    .SetFontSize(18));
                document.Add(new Paragraph($"Fecha de Emisión: {factura.FechaEmision:yyyy-MM-dd}"));
                document.Add(new Paragraph($"Fecha de Vencimiento: {factura.FechaVencimiento:yyyy-MM-dd}"));
                document.Add(new Paragraph($"Total: {factura.Total:C}"));
                document.Add(new Paragraph($"Matrícula ID: {factura.MatriculaId}"));
                document.Add(new Paragraph(" ")); // Espacio

                // Agrega los ítems de la factura
                document.Add(new Paragraph("Detalles de la Factura")
                    .SetFontSize(14));

                foreach (var item in factura.FacturaItems)
                {
                    var itemDetails = $"Descripción: {item.Descripcion}\n" +
                                      $"Cantidad: {item.Cantidad}\n" +
                                      $"Precio Unitario: {item.PrecioUnitario:C}\n" +
                                      $"Total Item: {item.TotalItem:C}";

                    document.Add(new Paragraph(itemDetails));
                    document.Add(new Paragraph(" ")); // Espacio
                }

                // Agrega un pie de página (si es necesario)
                document.Add(new Paragraph($"Fecha de Creación: {factura.CreatedAt:yyyy-MM-dd}"));
                document.Add(new Paragraph($"Última Actualización: {factura.UpdatedAt:yyyy-MM-dd}"));

                // Cerra el documento para completar el PDF
                document.Close();

                // Retorna los bytes del PDF generado
                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Obtiene los datos del crecimiento de matrículas.
        /// </summary>
        /// <returns>Lista con los datos del crecimiento de matrículas.</returns>
        public async Task<List<(DateTime Fecha, int NuevasMatriculas, int TotalMatriculas)>> ObtenerCrecimientoMatriculasAsync()
        {
            return await reporteRepository.ObtenerCrecimientoMatriculasAsync();
        }

        /// <summary>
        /// Obtiene los datos del informe contable.
        /// </summary>
        /// <param name="inicio">Fecha de inicio del rango.</param>
        /// <param name="fin">Fecha de fin del rango.</param>
        /// <returns>Lista con los datos del informe contable.</returns>
        public async Task<List<(DateTime Fecha, Decimal Ingreso, Decimal Gasto)>> ObtenerInformeContableAsync(DateTime inicio, DateTime fin)
        {
            return await reporteRepository.ObtenerInformeContableAsync(inicio, fin);
        }

        /// <summary>
        /// Obtiene las clases más atractivas.
        /// </summary>
        /// <returns>Lista con las clases más atractivas.</returns>
        public async Task<List<(string Clase, string Horario, int Cupos)>> ObtenerClasesMasAtractivasAsync()
        {
            return await reporteRepository.ObtenerClasesMasReservadasAsync();
        }


    }

}

