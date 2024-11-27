using SistemaGestionGimnasio.Modelos;
using SistemaGestionGimnasio.DataHandler;
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
    public partial class AsignarHorariosPuntosFuertesForm : Form
    {
        private readonly IDataHandler dataHandler;
        private List<Usuario> listUsuarios = new List<Usuario>();
        public AsignarHorariosPuntosFuertesForm(IDataHandler handler)
        {
            InitializeComponent();
            dataHandler = handler;
            this.Load += new EventHandler(AsignarHorariosPuntosFuertesForm_Load);
        }

        private void AsignarHorariosPuntosFuertesForm_Load(object sender, EventArgs e)
        {
            CargarHorarios();
            CargarEntrenadores();
            CargarPuntosFuertes();
           
        }

        private void CargarHorarios()
        {
            string rutaArchivo = Path.Combine("Assets", "horarios.txt"); 

            if (dataHandler.FileExists(rutaArchivo)) 
            {
                foreach (var linea in dataHandler.ReadAllLines(rutaArchivo)) 
                {
                    listBoxHorariosDisponibles.Items.Add(linea);
                }
            }
            else
            {
                MessageBox.Show("Archivo de horarios no encontrado.");
            }
        }

        // Método para cargar entrenadores en el ComboBox desde el archivo CSV
        private void CargarEntrenadores()
        {
            string rutaArchivo = "Assets/usuarios.csv";

            if (dataHandler.FileExists(rutaArchivo))
            {
                foreach (var linea in dataHandler.ReadAllLines(rutaArchivo))
                {
                    string[] datos = linea.Split(',');

                    if (datos.Length >= 4 && datos[3].Trim() == "Entrenador")
                    {
                        CmbEntrenador.Items.Add(datos[1]); 
                    }
                }
            }
            else
            {
                MessageBox.Show("Archivo de usuarios no encontrado.");
            }
        }


        private void CargarPuntosFuertes()
        {
            string rutaArchivo = "Assets/actividades.txt";

            if (dataHandler.FileExists(rutaArchivo))
            {
                foreach (var linea in dataHandler.ReadAllLines(rutaArchivo))
                {
                    listBoxPuntosFuertes.Items.Add(linea);
                }
            }
            else
            {
                MessageBox.Show("El archivo de actividades no existe.");
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            var entrenadorSeleccionado = CmbEntrenador.SelectedItem;
            var horarioSeleccionado = listBoxHorariosDisponibles.SelectedItem;

            if (entrenadorSeleccionado != null && horarioSeleccionado != null)
            {
                var entrenador = listUsuarios.OfType<Entrenador>().FirstOrDefault(u => u.Nombre == entrenadorSeleccionado.ToString());
                entrenador?.Horarios.Add(horarioSeleccionado.ToString());
                MessageBox.Show("Horario agregado exitosamente.");
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un entrenador y un horario.");
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string rutaArchivo = "Assets/puntosfuertes.csv";

            if (listBoxPuntosFuertes.SelectedItems.Count > 0)
            {
                var puntosFuertesSeleccionados = listBoxPuntosFuertes.SelectedItems.Cast<string>().ToArray();
                dataHandler.AppendLines(rutaArchivo, puntosFuertesSeleccionados);
                MessageBox.Show("Puntos fuertes guardados con éxito.");
            }
            else
            {
                MessageBox.Show("Por favor, seleccione al menos un punto fuerte para guardar.");
            }
        }

        private void BntCancelar_Click(object sender, EventArgs e)
        {
            listBoxPuntosFuertes.ClearSelected();
        }
    }
}




