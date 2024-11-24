using System;
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

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class ReporteCrecimientoForm : Form
    {
        private string rutaMembresias = "membresias.csv";
        private string rutaReporte = "ReporteMembresia.csv";
        public ReporteCrecimientoForm()
        {
            InitializeComponent();
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
    if (!File.Exists(rutaMembresias))
    {
        MessageBox.Show("El archivo de membresías no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }
            var registrosMembresias = new List<DateTime>();
            using (StreamReader lector = new StreamReader(rutaMembresias))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    string[] datos = linea.Split(',');
                    if (DateTime.TryParse(datos[1], out DateTime fechaInicioMembresia))
                    {
                        registrosMembresias.Add(fechaInicioMembresia);
                    }
                }
            }
            //Filtra las membresias por rango de fecha
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

            //Calcula el total acumulado

            int totalMembresias = 0;
            var reporte = new List<string>();
            foreach (var registro in membresiasPorFecha)
            {
                totalMembresias += registro.NuevasMembresias;
                reporte.Add($"{registro.Fecha:dd/MM/yyyy},{registro.NuevasMembresias},{totalMembresias}");
            }

            //Guarda y actualiza archivo ReporteMembresia.csv
            using (StreamWriter escritor = new StreamWriter(rutaReporte, false)) // Sobrescribe el archivo
            {
                escritor.WriteLine("Fecha de Registro,Membresías Nuevas,Total de Membresías");
                foreach (var linea in reporte)
                {
                    escritor.WriteLine(linea);
                }
            }
            MessageBox.Show("Reporte generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CargarDatosReporte()
        {
            if (!File.Exists(rutaReporte))
            {
                MessageBox.Show("El archivo del reporte no existe. Por favor, genera el reporte primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var tabla = new DataTable();
            tabla.Columns.Add("Fecha de Registro");
            tabla.Columns.Add("Membresías Nuevas");
            tabla.Columns.Add("Total de Membresías");

            using (StreamReader lector = new StreamReader(rutaReporte))
            {
                string linea;
                bool esCabecera = true;
                while ((linea = lector.ReadLine()) != null)
                {
                    if (esCabecera)
                    {
                        esCabecera = false;
                        continue;
                    }

                    string[] datos = linea.Split(',');
                    tabla.Rows.Add(datos);
                }
            }

            DgvReporte.DataSource = tabla;
        }

        private void GraficarDatos()
        {
            if (!File.Exists(rutaReporte))
            {
                MessageBox.Show("El archivo del reporte no existe. Por favor, genera el reporte primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var datosGrafico = new List<(DateTime Fecha, int TotalMembresias)>();

            using (StreamReader lector = new StreamReader(rutaReporte))
            {
                string linea;
                bool esCabecera = true;
                while ((linea = lector.ReadLine()) != null)
                {
                    if (esCabecera)
                    {
                        esCabecera = false;
                        continue;
                    }

                    string[] datos = linea.Split(',');
                    if (DateTime.TryParse(datos[0], out DateTime fecha) && int.TryParse(datos[2], out int total))
                    {
                        datosGrafico.Add((fecha, total));
                    }
                }
            }

            //Configura las series del grafico

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
