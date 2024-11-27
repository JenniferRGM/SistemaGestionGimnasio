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
using SistemaGestionGimnasio.DataHandler;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class EliminarClasesForm : Form
    {
        private Usuario usuarioActual;
        private readonly IDataHandler dataHandler;
        public EliminarClasesForm(Usuario usuario, IDataHandler dataHandler)
        {
            InitializeComponent();
            this.usuarioActual = usuario;
            this.dataHandler = dataHandler;
            CargarClases();
        }

        private void CargarClases()
        {
            string rutaArchivo = "Assets/actividades.csv";

            if (!dataHandler.FileExists(rutaArchivo))
            {
                MessageBox.Show("No se encontró el archivo de actividades.");
                return;
            }

            var lineas = dataHandler.ReadAllLines(rutaArchivo);
            foreach (var linea in lineas)
            {
                string[] datos = linea.Split(',');
                if (datos[0] == usuarioActual.Nombre)
                {
                    CmbClases.Items.Add(datos[1]);
                }
            }
        }
        private void EliminarClasesForm_Load(object sender, EventArgs e)
        {
            CargarClasesPorUsuario();
        }

        private void CargarClasesPorUsuario()
        {
            string rutaMatriculas = "Assets/matriculas.csv";

            if (!dataHandler.FileExists(rutaMatriculas))
            {
                MessageBox.Show("No hay clases matriculadas registradas.");
                return;
            }

            CmbClases.Items.Clear();
            DgvClasesMatriculadas.Rows.Clear();

            var lineas = dataHandler.ReadAllLines(rutaMatriculas);
            foreach (var linea in lineas)
            {
                string[] datos = linea.Split(',');

                // Filtrar solo las clases del usuario actual
                if (datos.Length > 1 && datos[0] == usuarioActual.Nombre)
                {
                    CmbClases.Items.Add(datos[1]);
                    DgvClasesMatriculadas.Rows.Add(datos[1]);
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
            string rutaActividades = "Assets/actividades.csv";
            string rutaMatriculas = "Assets/matriculas.csv";

            // Eliminar la clase del archivo actividades.csv
            if (dataHandler.FileExists(rutaActividades))
            {
                var lineas = dataHandler.ReadAllLines(rutaActividades)
                    .Where(linea => !linea.StartsWith(clase + ","))
                    .ToArray();
                dataHandler.WriteAllLines(rutaActividades, lineas);
            }

            // Eliminar la clase del archivo matriculas.csv
            if (dataHandler.FileExists(rutaMatriculas))
            {
                var lineas = dataHandler.ReadAllLines(rutaMatriculas)
                    .Where(linea =>
                    {
                        string[] datos = linea.Split(',');
                        return !(datos.Length > 1 && datos[0] == usuarioActual.Nombre && datos[1] == clase);
                    })
                    .ToArray();
                dataHandler.WriteAllLines(rutaMatriculas, lineas);
            }

            MessageBox.Show($"La clase '{clase}' ha sido eliminada correctamente.");
            CargarClasesPorUsuario();
        }
    }
}


