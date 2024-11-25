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

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class InformeContableForm : Form
    {
        public InformeContableForm()
        {
            InitializeComponent();
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

            string rutaArchivo = "InformeContable.csv";
            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("El archivo InformeContable.csv no existe.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal totalIngresos = 0;
            decimal totalGastos = 0;

            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    string[] datos = linea.Split(',');

                    if (datos.Length >= 4)
                    {
                        DateTime fechaRegistro = DateTime.Parse(datos[0]);
                        string descripcion = datos[1];
                        decimal ingreso = decimal.Parse(datos[2]);
                        decimal gasto = decimal.Parse(datos[3]);

                        if (fechaRegistro >= fechaInicio && fechaRegistro <= fechaFin)
                        {
                            DgvInformeContable.Rows.Add(fechaRegistro.ToString("dd/MM/yyyy"), descripcion, ingreso, gasto);

                            totalIngresos += ingreso;
                            totalGastos += gasto;

                        }
                    }
                }
            }

            //Muestra el resumen en labels

            LblTotalIngresos.Text = $"Total Ingresos: {totalIngresos:C}";
            LblTotalGastos.Text = $"Total Gastos: {totalGastos:C}";
            LblBalance.Text = $"Balance: {(totalIngresos - totalGastos):C}";
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





