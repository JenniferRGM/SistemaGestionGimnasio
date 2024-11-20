using SistemaGestionGimnasio.Modelos;
using SistemaGestionGimnasio.Vistas;
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
    public partial class Login : Form
    {
        private string usuarioActual;
        public Login()
        {
            InitializeComponent();
        }

        private void CbxMostrarClave_CheckedChanged(object sender, EventArgs e)
        {
            if (CbxMostrarClave.Checked)
            {
                txtClave.UseSystemPasswordChar = false;
            }
            else
            {
                txtClave.UseSystemPasswordChar = true;
            }
        }

        private void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtClave.Text;

            if (VerificarCredenciales(usuario, contraseña))
            {
                usuarioActual = usuario;
                Membresia membresia = Membresia.ObtenerMembresia(usuario);

                if (membresia != null)
                {
                    int diasRestantes = (membresia.FechaVencimiento - DateTime.Now).Days;
                    if (diasRestantes <= 5)
                    {
                        MessageBox.Show($"Tu membresía vence en {diasRestantes} días. ¡Renueva pronto!");
                    }
                    else
                    {
                        MessageBox.Show("Bienvenido al sistema");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró membresía asociada al usuario.");
                }

                // Redirige a la página principal
                UsuarioForm usuarioForm = new UsuarioForm(usuarioActual);
                usuarioForm.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Los datos introducidos no son correctos.");
            }
        }

        private static bool VerificarCredenciales(string usuario, string contraseña)
        {
            // Verificar en usuarios.csv
            if (BuscarEnArchivo("usuarios.csv", usuario.Trim(), contraseña.Trim()))
            {
                return true;
            }

            // Verificar en entrenadores.csv
            if (BuscarEnArchivo("entrenadores.csv", usuario.Trim(), contraseña.Trim()))
            {
                return true;
            }

            return false; // No se encontraron las credenciales en ninguno de los archivos
        }

        private static bool BuscarEnArchivo(string rutaArchivo, string usuario, string contraseña)
        {
            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show($"Archivo {rutaArchivo} no encontrado.");
                return false;
            }

            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    string[] datos = linea.Split(',');
                    if (datos.Length >= 6)// Asegurarse de que hay al menos usuario y contraseña
                    {
                        string usuarioArchivo = datos[4].Trim();
                        string contraseñaArchivo = datos[5].Trim();

                        if (usuarioArchivo == usuario && contraseñaArchivo == contraseña)
                        {
                            return true; // Credenciales coinciden
                        }
                    }
                }
            }

            return false; // No se encontraron las credenciales
        }
    }
}
