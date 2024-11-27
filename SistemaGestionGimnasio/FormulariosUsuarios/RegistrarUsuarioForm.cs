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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaGestionGimnasio
{
    public partial class RegistrarUsuarioForm : Form
    {
        private IDataHandler dataHandler;
        public RegistrarUsuarioForm(IDataHandler dataHandler)
        {
            InitializeComponent();
            this.Load += new EventHandler(RegistrarUsuarioForm_Load);
            this.dataHandler = dataHandler;
        }

        private void RegistrarUsuarioForm_Load(object sender, EventArgs e)
        {
            cmbTipo.Items.Clear();

            // Agregar elementos al ComboBox cuando se carga el formulario
            cmbTipo.Items.Add("Cliente");
            cmbTipo.Items.Add("Entrenador");
            cmbTipo.SelectedIndex = -1;

            txtID.ForeColor = Color.Gray;
            txtID.Text = "Digite su ID";
            txtNombre.ForeColor = Color.Gray;
            txtNombre.Text = "Digite su nombre completo";
            txtCorreo.ForeColor = Color.Gray;
            txtCorreo.Text = "Digite su correo";

            // Asociar los eventos para cada campo
            txtID.Enter += new EventHandler(RemoverPlaceholderID);
            txtID.Leave += new EventHandler(AgregarPlaceholderID);

            txtNombre.Enter += new EventHandler(RemoverPlaceholderNombre);
            txtNombre.Leave += new EventHandler(AgregarPlaceholderNombre);

            txtCorreo.Enter += new EventHandler(RemoverPlaceholderCorreo);
            txtCorreo.Leave += new EventHandler(AgregarPlaceholderCorreo);
           
    }
        private void RemoverPlaceholderID(object sender, EventArgs e)
            {
                if (txtID.Text == "Digite su ID")
                {
                    txtID.Text = "";
                    txtID.ForeColor = Color.Black;
                }
            }

        private void AgregarPlaceholderID(object sender, EventArgs e)
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    txtID.Text = "Digite su ID";
                    txtID.ForeColor = Color.Gray;
                }
            }

            private void RemoverPlaceholderNombre(object sender, EventArgs e)
            {
                if (txtNombre.Text == "Digite su nombre completo")
                {
                    txtNombre.Text = "";
                    txtNombre.ForeColor = Color.Black;
                }
            }

            private void AgregarPlaceholderNombre(object sender, EventArgs e)
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    txtNombre.Text = "Digite su nombre completo";
                    txtNombre.ForeColor = Color.Gray;
                }
            }
            private void RemoverPlaceholderCorreo(object sender, EventArgs e)
            {
                if (txtCorreo.Text == "Digite su correo")
                {
                    txtCorreo.Text = "";
                    txtCorreo.ForeColor = Color.Black;
                }
            }

            private void AgregarPlaceholderCorreo(object sender, EventArgs e)
            {
                if (string.IsNullOrWhiteSpace(txtCorreo.Text))
                {
                    txtCorreo.Text = "Digite su correo";
                    txtCorreo.ForeColor = Color.Gray;
                }
            }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) ||
                 string.IsNullOrWhiteSpace(txtNombre.Text) ||
                 string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                 cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            string id = txtID.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string tipo = cmbTipo.SelectedItem.ToString();

            // Crear la línea de datos para guardar
            string nuevaLinea = $"{id},{nombre},{correo},{tipo}";

            try
            {
                // Usar el dataHandler para guardar los datos
                dataHandler.AppendLine("usuarios.csv", nuevaLinea);

                MessageBox.Show($"Usuario guardado: {nombre}, {tipo}");

                // Limpiar los campos
                txtID.Clear();
                txtNombre.Clear();
                txtCorreo.Clear();
                cmbTipo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnInicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

