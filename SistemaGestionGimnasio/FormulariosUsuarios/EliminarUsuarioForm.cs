using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class EliminarUsuarioForm : Form
    {
        public EliminarUsuarioForm()
        {
            InitializeComponent();
        }

        private void EliminarUsuarioForm_Load(object sender, EventArgs e)
        {
            // Configurar los campos como solo lectura
            txtID.ReadOnly = true;
            txtNombre.ReadOnly = true;
            txtCorreo.ReadOnly = true;
            txtTipo.ReadOnly = true;

            // Placeholder para el campo de búsqueda
            txtBuscarID.ForeColor = Color.Gray;
            txtBuscarID.Text = "Digite el ID del usuario a buscar";

            txtBuscarID.Enter += new EventHandler(RemoverPlaceholder);
            txtBuscarID.Leave += new EventHandler(AgregarPlaceholder);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string idBuscado = txtBuscarID.Text;

            // Llama al método para buscar el usuario en el archivo CSV
            bool encontrado = BuscarUsuarioEnCsv(idBuscado);

            if (!encontrado)
            {
                MessageBox.Show("Usuario no encontrado");
            }
        }

        private bool BuscarUsuarioEnCsv(string idBuscado)
        {
            string rutaArchivo = "usuarios.csv";

            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("El archivo de usuarios no existe.");
                return false;
            }

            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    string[] datos = linea.Split(',');

                    if (datos[0] == idBuscado)
                    {
                        // Mostrar los datos del usuario en campos de solo lectura
                        txtID.Text = datos[0];
                        txtNombre.Text = datos[1];
                        txtCorreo.Text = datos[2];
                        txtTipo.Text = datos[3];
                        return true;
                    }
                }
            }

            return false;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            string idAEliminar = txtID.Text;

            if (string.IsNullOrEmpty(idAEliminar))
            {
                MessageBox.Show("Por favor, busque un usuario antes de intentar eliminar.");
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar este usuario?", "Confirmar Eliminación", MessageBoxButtons.YesNo);

            if (confirmacion == DialogResult.Yes)
            {
                bool eliminado = EliminarUsuarioEnCsv(idAEliminar);

                if (eliminado)
                {
                    MessageBox.Show("Usuario eliminado con éxito.");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el usuario.");
                }
            }
        }

            private static bool EliminarUsuarioEnCsv(string idAEliminar)
            {
                string rutaArchivo = "usuarios.csv";
                string rutaTemporal = "usuarios_temp.csv";
                bool usuarioEliminado = false;

                if (!File.Exists(rutaArchivo))
                {
                    MessageBox.Show("El archivo de usuarios no existe.");
                    return false;
                }

                using (StreamReader lector = new StreamReader(rutaArchivo))
                using (StreamWriter escritor = new StreamWriter(rutaTemporal))
                {
                    string linea;

                    while ((linea = lector.ReadLine()) != null)
                    {
                        string[] datos = linea.Split(',');

                        if (datos[0] == idAEliminar)
                        {
                            usuarioEliminado = true;
                            continue; // Omitir la línea que coincide con el usuario a eliminar
                        }

                        escritor.WriteLine(linea); // Escribir todas las demás líneas en el archivo temporal
                    }
                }
                if (usuarioEliminado)
                {
                    File.Delete(rutaArchivo);
                    File.Move(rutaTemporal, rutaArchivo);
                }
                else
                {
                    File.Delete(rutaTemporal);
                }

                return usuarioEliminado;
            }
            private void LimpiarCampos()
            {
                txtBuscarID.Clear();
                txtID.Clear();
                txtNombre.Clear();
                txtCorreo.Clear();
                txtTipo.Clear();
            }
    

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RemoverPlaceholder(object sender, EventArgs e)
        {
            if (txtBuscarID.Text == "Digite el ID del usuario a buscar")
            {
                txtBuscarID.Text = "";
                txtBuscarID.ForeColor = Color.Black;
            }
        }
        private void AgregarPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscarID.Text))
            {
                txtBuscarID.Text = "Digite el ID del usuario a buscar";
                txtBuscarID.ForeColor = Color.Gray;
            }
        }
    }
}
