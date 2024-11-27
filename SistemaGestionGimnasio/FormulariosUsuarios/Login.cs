using SistemaGestionGimnasio.DataHandler;
using SistemaGestionGimnasio.Modelos;
using SistemaGestionGimnasio.Vistas;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class Login : Form
    {
        private readonly IDataHandler dataHandler;
        private Usuario usuarioActual;

        public Login(IDataHandler handler)
        {
            InitializeComponent();
            dataHandler = handler;
        }

        private void CbxMostrarClave_CheckedChanged(object sender, EventArgs e)
        {
            txtClave.UseSystemPasswordChar = !CbxMostrarClave.Checked;
        }

        private void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtClave.Text.Trim();

            Usuario usuarioEncontrado = BuscarUsuarioEnArchivo("Assets/usuarios.csv", usuario, contraseña) ??
                                         BuscarUsuarioEnArchivo("Assets/entrenadores.csv", usuario, contraseña);

            if (usuarioEncontrado != null)
            {
                usuarioActual = usuarioEncontrado;

                
                if (usuarioActual is Cliente)
                {
                    Membresia membresia = Membresia.ObtenerMembresia(usuarioActual.NombreUsuario);

                    if (membresia != null)
                    {
                        int diasRestantes = (membresia.FechaVencimiento - DateTime.Now).Days;
                        if (diasRestantes <= 5)
                        {
                            MessageBox.Show($"Tu membresía vence en {diasRestantes} días. ¡Renueva pronto!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró una membresía asociada al usuario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Mostrar el formulario principal
                UsuarioForm principalForm = new UsuarioForm(usuarioActual);
                principalForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Los datos introducidos no son correctos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Usuario BuscarUsuarioEnArchivo(string rutaArchivo, string usuario, string contraseña)
        {
            if (!dataHandler.FileExists(rutaArchivo))
            {
                MessageBox.Show($"Archivo {rutaArchivo} no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            var lineas = dataHandler.ReadAllLines(rutaArchivo);
            bool esPrimeraLinea = true;

            foreach (var linea in lineas)
            {
                if (esPrimeraLinea)
                {
                    esPrimeraLinea = false;
                    continue;
                }

                string[] datos = linea.Split(',');
                if (datos.Length >= 6)
                {
                    if (!int.TryParse(datos[0], out int id))
                    {
                        continue;
                    }

                    string nombre = datos[1];
                    string correo = datos[2];
                    string tipo = datos[3];
                    string usuarioArchivo = datos[4];
                    string contraseñaArchivo = datos[5];

                    if (usuarioArchivo == usuario && contraseñaArchivo == contraseña)
                    {
                        if (tipo == "Cliente")
                            return new Cliente(id, nombre, correo, usuarioArchivo, contraseñaArchivo);
                        else if (tipo == "Entrenador")
                            return new Entrenador(id, nombre, correo, usuarioArchivo, contraseñaArchivo, "Puntos fuertes" );
                    }
                }
            }
            return null;
        }
    }
}



