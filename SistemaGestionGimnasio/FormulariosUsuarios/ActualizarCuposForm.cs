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
using SistemaGestionGimnasio.DataHandler;


namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class ActualizarCuposForm : Form
    {
        private readonly IDataHandler dataHandler;



        /// <summary>
        /// Constructor que inicializa el formulario y establece el manejador de datos (IDataHandler).
        /// </summary>
        /// <param name="handler">Instancia de IDataHandler para gestionar las operaciones de archivo.</param>
        public ActualizarCuposForm(IDataHandler handler)
        {
             InitializeComponent();
             dataHandler = handler; 
        }


        /// <summary>
        /// Evento que se ejecuta al cargar el formulario. 
        /// Carga las clases en el ComboBox al abrir el formulario.
        /// </summary>
        private void ActualizarCuposForm_Load(object sender, EventArgs e)
        {
            CargarClasesEnComboBox();
        }

        /// <summary>
        /// Carga las clases desde el archivo "actividades.csv" y las muestra en el ComboBox.
        /// </summary>
        private void CargarClasesEnComboBox()
        {
            string rutaArchivo = Path.Combine("Assets", "actividades.csv");

            if (!dataHandler.FileExists(rutaArchivo))
            {
                MessageBox.Show("No se encontraron clases registradas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CmbClases.Items.Clear();

            foreach (var linea in dataHandler.ReadAllLines(rutaArchivo))
            {
                string[] datos = linea.Split(',');

                if (datos.Length >= 1)
                {
                    CmbClases.Items.Add(datos[0]);
                }
            }
        }

        /// <summary>
        /// Evento asociado al botón para actualizar el cupo de una clase seleccionada.
        /// </summary>
        private void BtnActualizarCupo_Click(object sender, EventArgs e)
        {
            string claseSeleccionada = CmbClases.SelectedItem?.ToString();
            int nuevoCupo = (int)NumNuevoCupo.Value;

            if (string.IsNullOrEmpty(claseSeleccionada))
            {
                MessageBox.Show("Por favor, seleccione una clase.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ActualizarCupoEnArchivo(claseSeleccionada, nuevoCupo);
        }

        private void ActualizarCupoEnArchivo(string clase, int nuevoCupo)
        {
            string rutaArchivo = Path.Combine("Assets", "actividades.csv");
            string rutaTemporal = Path.Combine("Assets", "actividades_temp.csv");

            if (!dataHandler.FileExists(rutaArchivo))
            {
                MessageBox.Show("No se encontró el archivo de clases.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var lineas = dataHandler.ReadAllLines(rutaArchivo);
            var lineasActualizadas = new List<string>();
            bool actualizado = false;

            foreach (var linea in lineas)
            {
                string[] datos = linea.Split(',');

                if (datos.Length >= 5 && datos[0] == clase)
                {
                    lineasActualizadas.Add($"{datos[0]},{datos[4]},{nuevoCupo}");
                    actualizado = true;
                }
                else
                {
                    lineasActualizadas.Add(linea);
                }
            }

            if (!actualizado)
            {
                MessageBox.Show("La clase seleccionada no se encontró.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Escribimos las líneas actualizadas usando el DataHandler
            dataHandler.WriteAllLines(rutaTemporal, lineasActualizadas.ToArray());
            dataHandler.DeleteFile(rutaArchivo);
            dataHandler.MoveFile(rutaTemporal, rutaArchivo);

            MessageBox.Show("Cupo actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
