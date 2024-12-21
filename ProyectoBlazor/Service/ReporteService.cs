using SistemaGimnasio.Repository;
using System.IO;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using ProyectoBlazor.Modelos;
using iText.Layout.Properties;

namespace ProyectoBlazor.Service
{
    public class ReporteService
    {
        // Repositorio para obtener datos del reporte
        private readonly ReporteRepository reporteRepository;

        // Servicio de facturación para generar reportes relacionados con facturas
        private FacturacionService facturacionService;

        // Constructor para inicializar las dependencias
        public ReporteService(ReporteRepository reporteRepository, FacturacionService facturacionService)
        {
            this.reporteRepository = reporteRepository;
            this.facturacionService = facturacionService;
        }

        /// <summary>
        /// Genera un PDF básico con contenido personalizado.
        /// </summary>
        /// <returns>Array de bytes del PDF generado.</returns>
        public async Task<byte[]> GenerarReportePdf()
        {
            using (var memoryStream = new MemoryStream())
            {
                var writer = new PdfWriter(memoryStream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                // Agregar contenido al PDF
                document.Add(new Paragraph("Reporte Clases Más Atractivas"));
                document.Add(new Paragraph("Fecha: " + DateTime.Now.ToString("yyyy-MM-dd")));
                document.Add(new Paragraph("Aquí va el contenido de tu reporte..."));

                // Finalizar el documento
                document.Close();

                // Retornar los bytes del PDF
                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Genera un PDF con el reporte de crecimiento de matrículas.
        /// </summary>
        /// <returns>Array de bytes del PDF generado.</returns>
        public async Task<byte[]> GenerarReporteCrecimientoMatriculasPdf()
        {
            // datos del reporte de crecimiento de matrículas
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

                
                foreach (var item in reporteCrecimiento)
                {
                    var paragraph = new Paragraph($"Fecha: {item.Fecha.ToShortDateString()} - Nuevas Matrículas: {item.NuevasMatriculas} - Total Matrículas: {item.TotalMatriculas}");
                    document.Add(paragraph);
                }

                // Finaliza el documento
                document.Close();

                
                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Genera un PDF con el informe contable en un rango de fechas.
        /// </summary>
        /// <param name="inicio">Fecha de inicio.</param>
        /// <param name="fin">Fecha de fin.</param>
        /// <returns>Array de bytes del PDF generado.</returns>
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

                // datos del reporte
                var informeContable = await ObtenerInformeContableAsync(inicio, fin);

                // Agrega los datos al documento
                foreach (var item in informeContable)
                {
                    var paragraph = new Paragraph($"Fecha: {item.Fecha.ToShortDateString()} - Ingreso: {item.Ingreso:C} - Gasto: {item.Gasto:C}");
                    document.Add(paragraph);
                }

               
                document.Close();

              
                return memoryStream.ToArray();
            }
        }


        /// <summary>
        /// Genera un PDF con el reporte de las clases más reservadas.
        /// </summary>
        /// <returns>Array de bytes del PDF generado.</returns>
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

                
                var clasesAtractivas = await ObtenerClasesMasAtractivasAsync();

              
                foreach (var item in clasesAtractivas)
                {
                    var paragraph = new Paragraph($"Clase: {item.Clase} - Horario: {item.Horario} - Cupos disponibles: {item.Cupos}");
                    document.Add(paragraph);
                }

               
                document.Close();

                
                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Genera un PDF con los detalles de una factura específica.
        /// </summary>
        /// <param name="facturaId">ID de la factura.</param>
        /// <returns>Array de bytes del PDF generado.</returns>
        public async Task<byte[]> GenerarReporteFactura(int facturaId)
        {
            
            Factura factura = await facturacionService.ObtenerFacturaPorIdAsync(facturaId);

            
            using (var memoryStream = new MemoryStream())
            {
                
                var writer = new PdfWriter(memoryStream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                
                document.Add(new Paragraph("Factura No. " + factura.NumeroFactura)
                    .SetFontSize(18));
                document.Add(new Paragraph($"Fecha de Emisión: {factura.FechaEmision:yyyy-MM-dd}"));
                document.Add(new Paragraph($"Fecha de Vencimiento: {factura.FechaVencimiento:yyyy-MM-dd}"));
                document.Add(new Paragraph($"Total: {factura.Total:C}"));
                document.Add(new Paragraph($"Matrícula ID: {factura.MatriculaId}"));
                document.Add(new Paragraph(" ")); // Espacio

                
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

                
                document.Add(new Paragraph($"Fecha de Creación: {factura.CreatedAt:yyyy-MM-dd}"));
                document.Add(new Paragraph($"Última Actualización: {factura.UpdatedAt:yyyy-MM-dd}"));

               
                document.Close();

                
                return memoryStream.ToArray();
            }
        }

        public async Task<byte[]> GenerarReporteCrecimientoMatriculasAsync()
        {
            
            var crecimientoMatriculas = await reporteRepository.ObtenerCrecimientoMatriculasAsync();

            
            using (var memoryStream = new MemoryStream())
            {
               
                var writer = new PdfWriter(memoryStream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                
                document.Add(new Paragraph("Reporte de Crecimiento de Matrículas")
                    .SetFontSize(18)
                    .SetTextAlignment(TextAlignment.CENTER));
                document.Add(new Paragraph("Generado el: " + DateTime.Now.ToString("yyyy-MM-dd"))
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.RIGHT));
                document.Add(new Paragraph(" "));

                
                var table = new Table(3, true);
                table.AddHeaderCell(new Cell().Add(new Paragraph("Fecha")));
                table.AddHeaderCell(new Cell().Add(new Paragraph("Nuevas Matrículas")));
                table.AddHeaderCell(new Cell().Add(new Paragraph("Total Acumulado")));

                
                foreach (var (fecha, nuevasMatriculas, totalMatriculas) in crecimientoMatriculas)
                {
                    table.AddCell(new Cell().Add(new Paragraph(fecha.ToString("yyyy-MM-dd"))));
                    table.AddCell(new Cell().Add(new Paragraph(nuevasMatriculas.ToString())));
                    table.AddCell(new Cell().Add(new Paragraph(totalMatriculas.ToString())));
                }

                
                document.Add(table);

                
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph("Fin del Reporte")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(10));

                
                document.Close();

                
                return memoryStream.ToArray();
            }
        }




        // Método para obtener el crecimiento de matrículas
        public async Task<List<(DateTime Fecha, int NuevasMatriculas, int TotalMatriculas)>> ObtenerCrecimientoMatriculasAsync()
        {
            return await reporteRepository.ObtenerCrecimientoMatriculasAsync();
        }

        // Método para obtener el informe contable por rango de fechas
        public async Task<List<(DateTime Fecha, Decimal Ingreso, Decimal Gasto)>> ObtenerInformeContableAsync(DateTime inicio, DateTime fin)
        {
            return await reporteRepository.ObtenerInformeContableAsync(inicio, fin);
        }

        // Método para obtener las clases más atractivas
        public async Task<List<(string Clase, string Horario, int Cupos)>> ObtenerClasesMasAtractivasAsync()
        {
            return await reporteRepository.ObtenerClasesMasReservadasAsync();
        }


    }

}


