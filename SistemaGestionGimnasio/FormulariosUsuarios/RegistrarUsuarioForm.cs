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

namespace SistemaGestionGimnasio
{
    public partial class RegistrarUsuarioForm : Form
    {
        public RegistrarUsuarioForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(RegistrarUsuarioForm_Load);
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

        private static void GuardarUsuarioEnCsv(string id, string nombre, string correo, string tipo)
        {
            // Define la ruta del archivo CSV
            string rutaArchivo = "usuarios.csv";

            // Verifica si el archivo ya existe
            bool archivoExiste = File.Exists(rutaArchivo);

            // Usa StreamWriter para escribir en el archivo
            using (StreamWriter escritor = new StreamWriter(rutaArchivo, true))
            {
                // Escribe la cabecera del CSV solo si el archivo no existe
                if (!archivoExiste)
                {
                    escritor.WriteLine("ID,Nombre,Correo,Tipo");
                }

                // Escribe los datos del usuario en una nueva línea
                escritor.WriteLine($"{id},{nombre},{correo},{tipo}");
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(txtID.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            string id = txtID.Text;
            string nombre = txtNombre.Text;
            string correo = txtCorreo.Text;
            string tipo = cmbTipo.SelectedItem.ToString();

            // Llama al método para guardar en CSV
            GuardarUsuarioEnCsv(id, nombre, correo, tipo);

            MessageBox.Show($"Usuario guardado: {nombre}, {tipo}");

            // Confirmación y limpieza
            MessageBox.Show("Usuario guardado con éxito.");
            txtID.Clear();
            txtNombre.Clear();
            txtCorreo.Clear();
            cmbTipo.SelectedIndex = -1;
        }

    private void BtnInicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

