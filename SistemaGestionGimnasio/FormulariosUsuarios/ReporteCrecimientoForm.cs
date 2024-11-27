using System;
using SistemaGestionGimnasio.DataHandler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class ReporteCrecimientoForm : Form
    {
        private IDataHandler dataHandler;
        private string rutaMembresias = "Assets/membresias.csv";
        private string rutaReporte = "Assets/ReporteMembresia.csv";
        public ReporteCrecimientoForm(IDataHandler dataHandler)
        {
            InitializeComponent();
            this.dataHandler = dataHandler;
        }

        private void ReporteCrecimientoForm_Load(object sender, EventArgs e)
        {
            ConfigurarGrafico();
        }

        private void ConfigurarGrafico()
        {
            ChartCrecimiento.Series.Clear();
            ChartCrecimiento.Titles.Add("Crecimiento de Membresías");
            ChartCrecimiento.ChartAreas[0].AxisX.Title = "Fecha";
            ChartCrecimiento.ChartAreas[0].AxisY.Title = "Cantidad";
        }

        private void BtnGenerarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = FechaInicio.Value.Date;
                DateTime fechaFin = FechaFin.Value.Date;


                if (FechaInicio.Value > FechaFin.Value)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final.", "Fechas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                GenerarReporteMembresias(fechaInicio, fechaFin);

                CargarDatosReporte();

                GraficarDatos();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


private void GenerarReporteMembresias(DateTime fechaInicio, DateTime fechaFin)
{
            if (!dataHandler.FileExists(rutaMembresias))
            {
                MessageBox.Show("El archivo de membresías no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var registrosMembresias = new List<DateTime>();
            foreach (var linea in dataHandler.ReadAllLines(rutaMembresias))
            {
                string[] datos = linea.Split(',');
                if (DateTime.TryParse(datos[1], CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaInicioMembresia))
                {
                    registrosMembresias.Add(fechaInicioMembresia);
                }
            }

            var membresiasPorFecha = registrosMembresias
                .Where(fecha => fecha >= fechaInicio && fecha <= fechaFin)
                .GroupBy(fecha => fecha.Date)
                .Select(grupo => new
                {
                    Fecha = grupo.Key,
                    NuevasMembresias = grupo.Count()
                })
                .OrderBy(grupo => grupo.Fecha)
                .ToList();

            int totalMembresias = 0;
            var reporte = new List<string>
            {
                "Fecha de Registro,Membresías Nuevas,Total de Membresías"
            };

            foreach (var registro in membresiasPorFecha)
            {
                totalMembresias += registro.NuevasMembresias;
                reporte.Add($"{registro.Fecha:dd/MM/yyyy},{registro.NuevasMembresias},{totalMembresias}");
            }

            dataHandler.WriteAllLines(rutaReporte, reporte.ToArray());
            MessageBox.Show("Reporte generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CargarDatosReporte()
        {
            if (!dataHandler.FileExists(rutaReporte))
            {
                MessageBox.Show("El archivo del reporte no existe. Por favor, genera el reporte primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var tabla = new DataTable();
            tabla.Columns.Add("Fecha de Registro");
            tabla.Columns.Add("Membresías Nuevas");
            tabla.Columns.Add("Total de Membresías");

            foreach (var linea in dataHandler.ReadAllLines(rutaReporte).Skip(1)) // Omitir cabecera
            {
                string[] datos = linea.Split(',');
                tabla.Rows.Add(datos);
            }

            DgvReporte.DataSource = tabla;
        }

        private void GraficarDatos()
        {
            if (!dataHandler.FileExists(rutaReporte))
            {
                MessageBox.Show("El archivo del reporte no existe. Por favor, genera el reporte primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var datosGrafico = new List<(DateTime Fecha, int TotalMembresias)>();

            foreach (var linea in dataHandler.ReadAllLines(rutaReporte).Skip(1)) 
            {
                string[] datos = linea.Split(',');
                if (DateTime.TryParse(datos[0], CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha) &&
                      int.TryParse(datos[2], NumberStyles.Integer, CultureInfo.InvariantCulture, out int total))

                {
                    datosGrafico.Add((fecha, total));
                }
            }

            ChartCrecimiento.Series.Clear();
            var serie = new Series("Total Membresías")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3
            };

            foreach (var dato in datosGrafico)
            {
                serie.Points.AddXY(dato.Fecha, dato.TotalMembresias);
            }

            ChartCrecimiento.Series.Add(serie);
        }
    }
}
