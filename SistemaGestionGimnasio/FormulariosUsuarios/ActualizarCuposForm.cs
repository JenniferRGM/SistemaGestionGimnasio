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
    public partial class ActualizarCuposForm : Form
    {
        public ActualizarCuposForm()
        {
            InitializeComponent();
        }

        private void ActualizarCuposForm_Load(object sender, EventArgs e)
        {
            CargarClasesEnComboBox();
        }

        private void CargarClasesEnComboBox()
        {
            string rutaArchivo = "clases.csv";

            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("No se encontraron clases registradas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CmbClases.Items.Clear();

            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    string[] datos = linea.Split(',');

                    if (datos.Length >= 1)
                    {
                        CmbClases.Items.Add(datos[0]);
                    }
                }
            }
        }

        private void BtnActualizarCupo_Click(object sender, EventArgs e)
        {
            string claseSeleccionada = CmbClases.SelectedItem?.ToString();
            int nuevoCupo = (int)NumNuevoCupo.Value;

            if (string.IsNullOrEmpty(claseSeleccionada))
            {
                MessageBox.Show("Por favor, selecciona una clase.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ActualizarCupoEnArchivo(claseSeleccionada, nuevoCupo);
        }

        private static void ActualizarCupoEnArchivo(string clase, int nuevoCupo)
        {
            string rutaArchivo = "actividades.csv";
            string rutaTemporal = "actividades_temp.csv";

            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("No se encontró el archivo de clases.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (StreamReader lector = new StreamReader(rutaArchivo))
            using (StreamWriter escritor = new StreamWriter(rutaTemporal))
            {
                string linea;
                bool actualizado = false;

                while ((linea = lector.ReadLine()) != null)
                {
                    string[] datos = linea.Split(',');

                    if (datos.Length >= 3 && datos[0] == clase)
                    {
                        escritor.WriteLine($"{datos[0]},{datos[1]},{nuevoCupo}");
                        actualizado = true;
                    }

                    else
                    {
                        escritor.WriteLine(linea);
                    }
                }

                if (!actualizado)
                {
                    MessageBox.Show("La clase seleccionada no se encontró.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            File.Delete(rutaArchivo);
            File.Move(rutaTemporal, rutaArchivo);

            MessageBox.Show("Cupo actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

