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
using SistemaGestionGimnasio.DataHandler;
using System.Globalization;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class InformeContableForm : Form
    {
        private readonly IDataHandler dataHandler;
        public InformeContableForm(IDataHandler dataHandler)
        {
            InitializeComponent();
            this.dataHandler = dataHandler;
        }

        private void BtnGenerarInforme_Click(object sender, EventArgs e)
        {
            DgvInformeContable.Rows.Clear();

            DateTime fechaInicio = DtpFechaInicio.Value;
            DateTime fechaFin = DtpFechaFin.Value;

            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final.", "Error de Fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string rutaArchivo = "Assets/InformeContable.csv";
            if (!dataHandler.FileExists(rutaArchivo))
            {
                MessageBox.Show("El archivo InformeContable.csv no existe.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal totalIngresos = 0;
            decimal totalGastos = 0;

            try
            {
                var lineas = dataHandler.ReadAllLines(rutaArchivo).Skip(1);
                foreach (var linea in lineas)
                {
                    string[] datos = linea.Split(',');

                    if (datos.Length >= 4)
                    {
                        if (DateTime.TryParseExact(datos[0].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaRegistro) &&
                            decimal.TryParse(datos[2], out decimal ingreso) &&
                            decimal.TryParse(datos[3], out decimal gasto))
                        {
                            if (fechaRegistro >= fechaInicio && fechaRegistro <= fechaFin)
                            {
                                DgvInformeContable.Rows.Add(fechaRegistro.ToString("dd/MM/yyyy"), datos[1], ingreso, gasto);

                                totalIngresos += ingreso;
                                totalGastos += gasto;
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Error al procesar la línea: {linea}", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                // Mostrar el resumen en los labels
                LblTotalIngresos.Text = $" {totalIngresos:C}";
                LblTotalGastos.Text = $" {totalGastos:C}";
                LblBalance.Text = $" {(totalIngresos - totalGastos):C}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InformeContableForm_Load(object sender, EventArgs e)
        {
            DgvInformeContable.Columns.Add("Fecha", "Fecha");
            DgvInformeContable.Columns.Add("Descripcion", "Descripción");
            DgvInformeContable.Columns.Add("Ingreso", "Ingreso");
            DgvInformeContable.Columns.Add("Gasto", "Gasto");

        }
    }
}





