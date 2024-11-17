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

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class ConsultarClasesForm : Form
    {
        public ConsultarClasesForm()
        {
            InitializeComponent();
        }

        private void ConsultarClasesForm_Load(object sender, EventArgs e)
        {
            CargarClases();
        }

        private void CargarClases()
        {
            string rutaArchivo = "actividades.csv";

            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("No se encontraron clases registradas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DgvClases.Rows.Clear();

            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
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
}
