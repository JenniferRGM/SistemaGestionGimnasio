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
using SistemaGestionGimnasio.DataHandler;
using SistemaGestionGimnasio.Modelos;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class EliminarUsuarioForm : Form
    {
        private IDataHandler dataHandler;
        public EliminarUsuarioForm(IDataHandler dataHandler)
        {
            InitializeComponent();
            this.dataHandler = dataHandler;
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
            
            if (!BuscarUsuarioEnCsv(idBuscado))
            {
                MessageBox.Show("Usuario no encontrado");
            }
        }

        private bool BuscarUsuarioEnCsv(string idBuscado)
        {
        
            if (!dataHandler.FileExists("usuarios.csv"))
            {
                MessageBox.Show("El archivo de usuarios no existe.");
                return false;
            }
            foreach (var linea in dataHandler.ReadAllLines("usuarios.csv"))
            {
                string[] datos = linea.Split(',');

                if (datos[0] == idBuscado)
                {
                    txtID.Text = datos[0];
                    txtNombre.Text = datos[1];
                    txtCorreo.Text = datos[2];
                    txtTipo.Text = datos[3];
                    return true;
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
                if (EliminarUsuarioEnCsv(idAEliminar))
                {
                    MessageBox.Show("Usuario eliminado con éxito.");
                    RestablecerCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el usuario.");
                }
            }
        }

        private bool EliminarUsuarioEnCsv(string idAEliminar)
        {
           
            string rutaTemporal = "Assets/usuarios_temp.csv";
            bool usuarioEliminado = false;

            if (!dataHandler.FileExists("usuarios.csv"))
            {
                MessageBox.Show("El archivo de usuarios no existe.");
                return false;
            }

            var lineas = dataHandler.ReadAllLines("usuarios.csv");
            var lineasActualizadas = lineas.Where(linea => !linea.StartsWith(idAEliminar + ",")).ToArray();

            if (lineas.Length != lineasActualizadas.Length)
            {
                dataHandler.WriteAllLines(rutaTemporal, lineasActualizadas);
                dataHandler.DeleteFile("usuarios.csv");
                dataHandler.MoveFile(rutaTemporal, "usuarios.csv");
                usuarioEliminado = true;
            }
            else
            {
                dataHandler.DeleteFile(rutaTemporal);
            }

            return usuarioEliminado;
        }

        private void RestablecerCampos()
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
