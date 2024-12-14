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

            try
            {

                var lineas = dataHandler.ReadAllLines(rutaMatriculas);
                bool esPrimeraLinea = true;


                foreach (var linea in lineas)
                {
                    if (esPrimeraLinea)
                    {
                        esPrimeraLinea = false; // Ignora la primera línea
                        continue;
                    }

                    string[] datos = linea.Split(',');

                    if (datos.Length < 2)
                    {
                        continue;
                    }

                    // Filtra solo las clases del usuario actual
                    if (datos[0].Trim().Equals(usuarioActual.Nombre.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        CmbClases.Items.Add(datos[1]);
                        DgvClasesMatriculadas.Rows.Add(datos[0].Trim(), datos[1]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las clases matriculadas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
           
            string rutaMatriculas = "Assets/matriculas.csv";

            // Eliminar la clase del archivo actividades.csv
            if (dataHandler.FileExists(rutaMatriculas))
            {
                var lineas = dataHandler.ReadAllLines(rutaMatriculas)
                    .Where(linea =>
                    {
                        string[] datos = linea.Split(',');
                        return !(datos.Length > 1 && datos[0].Trim().Equals(usuarioActual.Nombre.Trim(), StringComparison.OrdinalIgnoreCase) && datos[1].Trim().Equals(clase.Trim(), StringComparison.OrdinalIgnoreCase));
                    })
                    .ToArray();
                dataHandler.WriteAllLines(rutaMatriculas, lineas);
            }

           
            

            MessageBox.Show($"La clase '{clase}' ha sido eliminada correctamente.");
            CargarClasesPorUsuario();
        }
    }
}


