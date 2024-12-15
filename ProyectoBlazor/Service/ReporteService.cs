﻿using SistemaGimnasio.Repository;

using System.IO;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace ProyectoBlazor.Service
{
    public class ReporteService
    {
        private readonly ReporteRepository reporteRepository;

        public ReporteService(ReporteRepository reporteRepository)
        {
            this.reporteRepository = reporteRepository;
        }

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

        public async Task<byte[]> GenerarReporteCrecimientoMatriculasPdf()
        {
            // Obtener los datos del reporte de crecimiento de matrículas
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

                // Agregar los datos al documento desde la lista 'reporteCrecimiento'
                foreach (var item in reporteCrecimiento)
                {
                    var paragraph = new Paragraph($"Fecha: {item.Fecha.ToShortDateString()} - Nuevas Matrículas: {item.NuevasMatriculas} - Total Matrículas: {item.TotalMatriculas}");
                    document.Add(paragraph);
                }

                // Finalizar el documento
                document.Close();

                // Retornar los bytes del PDF
                return memoryStream.ToArray();
            }
        }

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

                // Obtener los datos del reporte
                var informeContable = await ObtenerInformeContableAsync(inicio, fin);

                // Agregar los datos al documento
                foreach (var item in informeContable)
                {
                    var paragraph = new Paragraph($"Fecha: {item.Fecha.ToShortDateString()} - Ingreso: {item.Ingreso:C} - Gasto: {item.Gasto:C}");
                    document.Add(paragraph);
                }

                // Finalizar el documento
                document.Close();

                // Retornar los bytes del PDF
                return memoryStream.ToArray();
            }
        }


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

                // Obtener los datos del reporte
                var clasesAtractivas = await ObtenerClasesMasAtractivasAsync();

                // Agregar los datos al documento
                foreach (var item in clasesAtractivas)
                {
                    var paragraph = new Paragraph($"Clase: {item.Clase} - Horario: {item.Horario} - Cupos disponibles: {item.Cupos}");
                    document.Add(paragraph);
                }

                // Finalizar el documento
                document.Close();

                // Retornar los bytes del PDF
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
