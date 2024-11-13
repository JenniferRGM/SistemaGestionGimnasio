using SistemaGestionGimnasio.Modelos;
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
        private List<Usuario> listUsuarios = new List<Usuario>();
        public AsignarHorariosPuntosFuertesForm()
        {
            InitializeComponent();
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
            string rutaArchivo = "horarios.txt";

            if (File.Exists(rutaArchivo))
            {
                using (StreamReader lector = new StreamReader(rutaArchivo))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {
                        listBoxHorariosDisponibles.Items.Add(linea);
                    }
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
            string rutaArchivo = "usuarios.csv";

            if (File.Exists(rutaArchivo))
            {
                using (StreamReader lector = new StreamReader(rutaArchivo))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {
                        string[] datos = linea.Split(',');

                        // Comprobar si el usuario es un entrenador
                        if (datos.Length >= 4 && datos[3].Trim() == "Entrenador")
                        {
                            CmbEntrenador.Items.Add(datos[1]); // Añadir el nombre del entrenador
                        }
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
            string rutaArchivo = "actividades.txt";

            if (File.Exists(rutaArchivo))
            {
                using (StreamReader lector = new StreamReader(rutaArchivo))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {
                        listBoxPuntosFuertes.Items.Add(linea);
                    }
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
                var usuario = listUsuarios.Find(u => u.Nombre == entrenadorSeleccionado.ToString());
                usuario?.Horarios.Add(horarioSeleccionado.ToString());
                MessageBox.Show("Horario agregado exitosamente.");
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un entrenador y un horario.");
            }
        }


        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string rutaArchivo = "puntosfuertes.csv";

            if (listBoxPuntosFuertes.SelectedItems.Count > 0)
            {
                using (StreamWriter escritor = new StreamWriter(rutaArchivo, true)) // true para agregar en lugar de sobrescribir
                {
                    foreach (var item in listBoxPuntosFuertes.SelectedItems)
                    {
                        escritor.WriteLine(item.ToString());
                    }
                }
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




