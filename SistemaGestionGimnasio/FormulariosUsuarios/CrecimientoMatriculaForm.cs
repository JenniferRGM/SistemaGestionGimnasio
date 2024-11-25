using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class CrecimientoMatriculaForm : Form
    {
        public CrecimientoMatriculaForm()
        {
            InitializeComponent();

        }
        private void CrecimientoMatriculaForm_Load(object sender, EventArgs e)
        {
            DgvCrecimiento.Columns.Add("FechaRegistro", "Fecha de Registro");
            DgvCrecimiento.Columns.Add("MembresiasNuevas", "Membresías Nuevas");
            DgvCrecimiento.Columns.Add("TotalMembresias", "Total de Membresías");

        }

        private void BtnGenerarReporte_Click(object sender, EventArgs e)
        {
            DgvCrecimiento.Rows.Clear();

            string rutaArchivo = "ReporteMembresia.csv";

            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("El archivo ReporteMembresia.csv no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (StreamReader lector = new StreamReader(rutaArchivo))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {

                        string[] datos = linea.Split(',');

                        if (datos.Length >= 3)
                        {
                            string fechaRegistro = datos[0];
                            string membresiasNuevas = datos[1];
                            string totalMembresias = datos[2];

                            DgvCrecimiento.Rows.Add(fechaRegistro, membresiasNuevas, totalMembresias);
                        }
                    }
                }

                MessageBox.Show("Datos cargados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}







