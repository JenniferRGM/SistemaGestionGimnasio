using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using SistemaGestionGimnasio.DataHandler;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class ConsultarMembresiasForm : Form
    {
        private IDataHandler dataHandler;
        public ConsultarMembresiasForm(IDataHandler dataHandler)
        {
            InitializeComponent();
            CargarMembresias();
            this.dataHandler = dataHandler;
        }

        private void CargarMembresias()
        {
            if (dataHandler == null)
            {
                MessageBox.Show("El manejador de datos no está inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string rutaArchivo = "Assets/membresias.csv"; 

            if (!dataHandler.FileExists(rutaArchivo)) 
            {
                MessageBox.Show("El archivo de membresías no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var datos = dataHandler.ReadLines(rutaArchivo); 
                DgvMembresias.Rows.Clear(); 

                foreach (var linea in datos)
                {
                    var valores = linea.Split(','); 
                    DgvMembresias.Rows.Add(valores);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar las membresías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarMembresias();
        }
    }
}


