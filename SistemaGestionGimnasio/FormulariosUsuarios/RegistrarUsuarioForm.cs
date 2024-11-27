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

            //evento KeyPress al TextBox ID
            txtID.KeyPress += new KeyPressEventHandler(ValidarSoloNumeros);
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
    
        // Método para permitir solo números en el campo txtID
        private void ValidarSoloNumeros(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
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
            // Verificar que todos los campos estén completos
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

            // Generar usuario y contraseña automáticamente
            string usuario = GenerarUsuario(nombre);
            string contraseña = GenerarContraseña();

            // Crear la línea de datos para guardar
            string nuevaLinea = $"{id},{nombre},{correo},{tipo},{usuario},{contraseña}";

            try
            {
                if (tipo.Equals("Cliente", StringComparison.OrdinalIgnoreCase))
                {
                    // Guardar en usuarios.csv para clientes
                    dataHandler.AppendLine("Assets/usuarios.csv", nuevaLinea);
                    MessageBox.Show($"Cliente guardado: {nombre}\nUsuario: {usuario}\nContraseña: {contraseña}");
                }
                else if (tipo.Equals("Entrenador", StringComparison.OrdinalIgnoreCase))
                {
                    // Guardar en entrenadores.csv para entrenadores
                    dataHandler.AppendLine("Assets/entrenadores.csv", nuevaLinea);
                    MessageBox.Show($"Entrenador guardado: {nombre}\nUsuario: {usuario}\nContraseña: {contraseña}");
                }
                else
                {
                    MessageBox.Show($"El tipo de usuario {tipo} no está definido para guardar en un archivo.");
                }

                // Limpiar los campos del formulario
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

        private static string GenerarUsuario(string nombreCompleto)
        {
            string[] nombres = nombreCompleto.Split(' ');
            string primerNombre = nombres[0].ToLower();

            Random random = new Random();
            int numero = random.Next(10, 99);

            return $"{primerNombre}{numero}";
        }

        private static string GenerarContraseña()
        {
            const int longitud = 8; // Longitud de la contraseña
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
            Random random = new Random();
            StringBuilder contraseña = new StringBuilder(longitud);

            for (int i = 0; i < longitud; i++)
            {
                contraseña.Append(caracteres[random.Next(caracteres.Length)]);
            }

            return contraseña.ToString();
        }
        private void BtnInicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

