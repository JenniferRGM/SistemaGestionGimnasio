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
            this.dataHandler = dataHandler;
           
            
        }

        private void ConsultarMembresiasForm_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarMembresias();
        }

        private void ConfigurarDataGridView()
        {
            DgvMembresias.Columns.Clear();
            DgvMembresias.Columns.Add("Usuario", "Usuario");
            DgvMembresias.Columns.Add("FechaInicio", "Fecha de Inicio");
            DgvMembresias.Columns.Add("FechaVencimiento", "Fecha de Vencimiento");
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
                var lineas = dataHandler.ReadAllLines(rutaArchivo);
                bool esPrimeraLinea = true;
                DgvMembresias.Rows.Clear(); 

                foreach (var linea in lineas)
                {
                    if (esPrimeraLinea)
                    {
                        esPrimeraLinea = false; // Ignorar el encabezado
                        continue;
                    }
                    string[] datos = linea.Split(',');

                    if (datos.Length < 3)
                    {
                        continue;
                    }

                    string usuario = datos[0].Trim();
                    string fechaInicio = datos[1].Trim();
                    string fechaVencimiento = datos[2].Trim();

                    DgvMembresias.Rows.Add(usuario, fechaInicio, fechaVencimiento);
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


