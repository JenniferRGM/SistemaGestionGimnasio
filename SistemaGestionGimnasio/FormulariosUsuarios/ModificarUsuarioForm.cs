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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class ModificarUsuarioForm : Form
    {
        public ModificarUsuarioForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(ModificarUsuarioForm_Load);
        }

        private void ModificarUsuarioForm_Load(object sender, EventArgs e)
        {
            // Configurar los campos como solo lectura
            txtID.ReadOnly = true;

            // Inicializar el ComboBox con los tipos de usuario
            cmbTipo.Items.Add("Cliente");
            cmbTipo.Items.Add("Entrenador");
            cmbTipo.SelectedIndex = -1;

            // Configurar el placeholder para el campo de búsqueda
            txtBuscarID.ForeColor = Color.Gray;
            txtBuscarID.Text = "ID de usuario";

            // Agregar eventos para simular el placeholder
            txtBuscarID.Enter += new EventHandler(RemoverPlaceholder);
            txtBuscarID.Leave += new EventHandler(AgregarPlaceholder);
        }

        private void RemoverPlaceholder(object sender, EventArgs e)
        {
            if (txtBuscarID.Text == "ID de usuario")
            {
                txtBuscarID.Text = "";
                txtBuscarID.ForeColor = Color.Black;
            }
        }

        private void AgregarPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscarID.Text))
            {
                txtBuscarID.Text = "ID de usuario";
                txtBuscarID.ForeColor = Color.Gray;
            }
        }


        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string idBuscado = txtBuscarID.Text;
            bool usuarioEncontrado = false;

             // Ruta del archivo CSV
            string rutaArchivo = "usuarios.csv";

            // Verificar si el archivo existe
            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("El archivo de usuarios no existe.");
                return;
            }

            // Leer el archivo CSV y buscar el usuario
            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                // Leer cada línea del archivo
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    // Dividir la línea en columnas (ID, Nombre, Correo, Tipo)
                    string[] datos = linea.Split(',');

                    // Verificar si la primera columna (ID) coincide con el ID buscado
                    if (datos[0] == idBuscado)
                    {
                        // Llenar los campos con los datos del usuario
                        txtID.Text = datos[0];
                        txtNombre.Text = datos[1];
                        txtCorreo.Text = datos[2];
                        cmbTipo.SelectedItem = datos[3];

                        usuarioEncontrado = true;
                        break;
                    }
                }
            }

            // Mensaje si el usuario no fue encontrado
            if (!usuarioEncontrado)
            {
                MessageBox.Show("Usuario no encontrado");
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, escriba el ID de usuario.");
                return;
            }

            // Obtener los datos del usuario modificado
            string id = txtID.Text;
            string nombre = txtNombre.Text;
            string correo = txtCorreo.Text;
            string tipo = cmbTipo.SelectedItem.ToString();

            // Llama al método para actualizar el usuario en el archivo CSV
            bool actualizado = ActualizarUsuarioEnCsv(id, nombre, correo, tipo);

            if (actualizado)
            {
                MessageBox.Show("Usuario modificado con éxito.");
            }
        }
        private static bool ActualizarUsuarioEnCsv(string id, string nombre, string correo, string tipo)
        {
            string rutaArchivo = "usuarios.csv";
            string rutaTemporal = "usuarios_temp.csv";
            bool usuarioEncontrado = false;

            // Verificar si el archivo CSV existe
            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("El archivo de usuarios no existe.");
                return false;
            }

            // Leer el archivo original y escribir en un archivo temporal con las modificaciones
            using (StreamReader lector = new StreamReader(rutaArchivo))
            using (StreamWriter escritor = new StreamWriter(rutaTemporal))
            {
                string linea;

                while ((linea = lector.ReadLine()) != null)
                {
                    string[] datos = linea.Split(',');

                    // Verificar si el ID coincide
                    if (datos[0] == id)
                    {
                        // Escribir los datos modificados en lugar de los originales
                        escritor.WriteLine($"{id},{nombre},{correo},{tipo}");
                        usuarioEncontrado = true;
                    }
                    else
                    {
                        // Escribir la línea original si no es el usuario que buscamos
                        escritor.WriteLine(linea);
                    }
                }
            }

            // Reemplazar el archivo original con el archivo temporal
            if (usuarioEncontrado)
            {
                File.Delete(rutaArchivo);
                File.Move(rutaTemporal, rutaArchivo);
            }
            else
            {
                // Si no se encontró el usuario, eliminamos el archivo temporal
                File.Delete(rutaTemporal);
            }

            return usuarioEncontrado;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModificarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarUsuarioForm modificarForm = new ModificarUsuarioForm();
            modificarForm.ShowDialog();
        }

    }
}
    
    

