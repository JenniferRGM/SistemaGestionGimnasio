using System;
using SistemaGestionGimnasio.DataHandler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class ConsultarClasesForm : Form
    {
        private readonly IDataHandler dataHandler;
        public ConsultarClasesForm(IDataHandler dataHandler)
        {
            InitializeComponent();
            this.dataHandler = dataHandler;
        }

        private void ConsultarClasesForm_Load(object sender, EventArgs e)
        {
            CargarClases();
        }

        private void CargarClases()
        {
            string rutaArchivo = "Assets/actividades.csv";

            if (!dataHandler.FileExists(rutaArchivo))
            {
                MessageBox.Show("No se encontraron clases registradas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DgvClases.Rows.Clear();

            foreach (var linea in dataHandler.ReadAllLines(rutaArchivo)) 
            {
                string[] datos = linea.Split(',');

                if (datos.Length >= 3)
                {
                    DgvClases.Rows.Add(datos[0], datos[1], datos[2]);
                }
            }
        }
    }
}