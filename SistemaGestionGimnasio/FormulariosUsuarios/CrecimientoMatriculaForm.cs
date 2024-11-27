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
using SistemaGestionGimnasio.DataHandler;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class CrecimientoMatriculaForm : Form
    {
        private readonly IDataHandler dataHandler;
        public CrecimientoMatriculaForm(IDataHandler dataHandler)
        {
            InitializeComponent();
            this.dataHandler = dataHandler;
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

            string rutaArchivo = "Assets/ReporteMembresia.csv";

            if (!dataHandler.FileExists(rutaArchivo))
            {
                MessageBox.Show("El archivo ReporteMembresia.csv no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var lineas = dataHandler.ReadAllLines(rutaArchivo);
                foreach (var linea in lineas)
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

                MessageBox.Show("Datos cargados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}







