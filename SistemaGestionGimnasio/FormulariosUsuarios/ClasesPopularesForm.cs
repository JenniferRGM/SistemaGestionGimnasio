using SistemaGestionGimnasio.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;


namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class ClasesPopularesForm : Form
    {
        public ClasesPopularesForm()
        {
            InitializeComponent();

            CmbCategoria.Items.AddRange(new string[] { "Yoga", "Pilates", "Spinning", "CrossFit" });
            DtpFechaInicio.Value = DateTime.Now.AddMonths(-1);
            DtpFechaFin.Value = DateTime.Now;
        }


        private void BtnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (DtpFechaInicio.Value > DtpFechaFin.Value)

            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime fechaInicio = DtpFechaInicio.Value;
            DateTime fechaFin = DtpFechaFin.Value;

            List<ClasesPopulares> clasesPopulares = ObtenerClasesPopulares(fechaInicio, fechaFin);

            DgvClases.Rows.Clear();
            foreach (var clase in clasesPopulares)
            {
                DgvClases.Rows.Add(clase.Nombre, clase.Asistentes, clase.Horario);
            }

            if (clasesPopulares.Count == 0)
            {
                MessageBox.Show("No se encontraron clases populares en el rango de fechas seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                GenerarGrafico(clasesPopulares);

            }
        }

        private List<ClasesPopulares> ObtenerClasesPopulares(DateTime fechaInicio, DateTime fechaFin)
        {
            List<ClasesPopulares> listaClases = new List<ClasesPopulares>();

            try
            {
                string[] lineas = File.ReadAllLines("clasesPopulares.csv");
                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split(',');
                    string nombre = datos[0];
                    int asistentes = int.Parse(datos[1]);
                    string horario = datos[2];
                    DateTime fecha = DateTime.Parse(datos[3], CultureInfo.InvariantCulture);

                    if (fecha >= fechaInicio && fecha <= fechaFin)
                    {
                        listaClases.Add(new ClasesPopulares
                        {
                            Nombre = nombre,
                            Asistentes = asistentes,
                            Horario = horario
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listaClases;


        }
        private void GenerarGrafico(List<ClasesPopulares> clasesPopulares)
        {
            ChartClases.Series.Clear();
            var serie = ChartClases.Series.Add("Clases Más Atractivas");

            foreach (var clase in clasesPopulares)
            {
                serie.Points.AddXY(clase.Nombre, clase.Asistentes);
            }
            serie.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            ChartClases.ChartAreas[0].AxisX.Interval = 1;
        }
    }

    
}
