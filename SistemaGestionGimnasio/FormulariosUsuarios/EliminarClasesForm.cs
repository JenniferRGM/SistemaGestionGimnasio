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
using SistemaGestionGimnasio.Modelos;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class EliminarClasesForm : Form
    {
        private string usuarioActual;
        public EliminarClasesForm(string usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            CargarClases();
        }

        private void CargarClases()
        {
            string rutaArchivo = "actividades.csv";

            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("No se encontró el archivo de actividades.");
                return;
            }

            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    string[] datos = linea.Split(',');
                    if (datos[0] == usuarioActual) 
                    {
                        CmbClases.Items.Add(datos[1]); 
                    }
                }
            }
        }

        private void EliminarClasesForm_Load(object sender, EventArgs e)
        {
            CargarClasesPorUsuario();
        }

        private void CargarClasesPorUsuario()
        {
            string rutaMatriculas = "matriculas.csv";

            if (!File.Exists(rutaMatriculas))
            {
                MessageBox.Show("No hay clases matriculadas registradas.");
                return;
            }

            CmbClases.Items.Clear();
            DgvClasesMatriculadas.Rows.Clear();

            using (StreamReader lector = new StreamReader(rutaMatriculas))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    string[] datos = linea.Split(',');

                    // Filtrar solo las clases del usuario actual
                    if (datos.Length > 1 && datos[0] == usuarioActual)
                    {
                        CmbClases.Items.Add(datos[1]); 
                        DgvClasesMatriculadas.Rows.Add(datos[1]); 
                    }
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (CmbClases.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona una clase para eliminar.");
                return;
            }

            string claseSeleccionada = CmbClases.SelectedItem.ToString();
            EliminarClase(claseSeleccionada);
        }

        private void EliminarClase(string clase)
        {
            string rutaActividades = "actividades.csv";
            string rutaMatriculas = "matriculas.csv";

            // Eliminar la clase del archivo actividades.csv
            if (File.Exists(rutaActividades))
            {
                var lineas = File.ReadAllLines(rutaActividades).Where(linea => !linea.StartsWith(clase + ",")).ToArray();
                File.WriteAllLines(rutaActividades, lineas);
            }

            // Eliminar la clase del archivo matriculas.csv
            if (File.Exists(rutaMatriculas))
            {
                var lineas = File.ReadAllLines(rutaMatriculas)
                                 .Where(linea =>
                                 {
                                     string[] datos = linea.Split(',');
                                     return !(datos.Length > 1 && datos[0] == usuarioActual && datos[1] == clase);
                                 })
                                 .ToArray();
                File.WriteAllLines(rutaMatriculas, lineas);
            }

            MessageBox.Show($"La clase '{clase}' ha sido eliminada correctamente.");
            CargarClasesPorUsuario(); 
        }
    }
}
    

