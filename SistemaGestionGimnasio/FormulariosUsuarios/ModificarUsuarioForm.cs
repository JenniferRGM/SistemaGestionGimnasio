using SistemaGestionGimnasio.DataHandler;
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
        private readonly IDataHandler dataHandler;
        public ModificarUsuarioForm(IDataHandler handler)
        {
            InitializeComponent();
            dataHandler = handler;
            this.Load += new EventHandler(ModificarUsuarioForm_Load);
            
        }

        private void ModificarUsuarioForm_Load(object sender, EventArgs e)
        {
            
            txtID.ReadOnly = true;

            
            cmbTipo.Items.Add("Cliente");
            cmbTipo.Items.Add("Entrenador");
            cmbTipo.SelectedIndex = -1;

            
            txtBuscarID.ForeColor = Color.Gray;
            txtBuscarID.Text = "ID de usuario";

            
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

           
            if (!dataHandler.FileExists("Assets/usuarios.csv"))
            {
                MessageBox.Show("El archivo de usuarios no existe.");
                return;
            }

            foreach (var linea in dataHandler.ReadAllLines("Assets/usuarios.csv"))
            {
                string[] datos = linea.Split(',');

                if (datos[0] == idBuscado)
                {
                    txtID.Text = datos[0];
                    txtNombre.Text = datos[1];
                    txtCorreo.Text = datos[2];
                    cmbTipo.SelectedItem = datos[3];

                    usuarioEncontrado = true;
                    break;
                }
            }

            if (!usuarioEncontrado)
            {
                MessageBox.Show("Usuario no encontrado");
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, escriba el ID de usuario.");
                return;
            }

            
            string id = txtID.Text;
            string nombre = txtNombre.Text;
            string correo = txtCorreo.Text;
            string tipo = cmbTipo.SelectedItem.ToString();

            
            bool actualizado = ActualizarUsuarioEnCsv(id, nombre, correo, tipo);

            if (actualizado)
            {
                MessageBox.Show("Usuario modificado con éxito.");
            }
        }
        private bool ActualizarUsuarioEnCsv(string id, string nombre, string correo, string tipo)
        {
            string[] lineas = dataHandler.ReadAllLines("Assets/usuarios.csv");
            bool usuarioEncontrado = false;

            for (int i = 0; i < lineas.Length; i++)
            {
                string[] datos = lineas[i].Split(',');

                if (datos[0] == id)
                {
                    lineas[i] = $"{id},{nombre},{correo},{tipo}";
                    usuarioEncontrado = true;
                    break;
                }
            }

            if (usuarioEncontrado)
            {
                dataHandler.WriteAllLines("usuarios.csv", lineas);
            }

            return usuarioEncontrado;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModificarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataHandler dataHandler = new FileDataHandler();
            ModificarUsuarioForm modificarForm = new ModificarUsuarioForm(dataHandler);
            modificarForm.ShowDialog();
        }

    }
}
    
    

