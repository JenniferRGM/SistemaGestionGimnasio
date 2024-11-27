using SistemaGestionGimnasio.DataHandler;
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
            string usuario = txtUsuario.Text;
            string contraseña = txtClave.Text;

            Usuario usuarioEncontrado = BuscarUsuarioEnArchivo("usuarios.csv", usuario, contraseña) ??
                                 BuscarUsuarioEnArchivo("entrenadores.csv", usuario, contraseña);

            if (usuarioEncontrado != null)
            {
                usuarioActual = usuarioEncontrado;

                // Validar membresía solo si el usuario es cliente
                if (usuarioActual is Cliente)
                {
                    Membresia membresia = Membresia.ObtenerMembresia(usuarioActual.Nombre);

                    if (membresia != null)
                    {
                        int diasRestantes = (membresia.FechaVencimiento - DateTime.Now).Days;
                        if (diasRestantes <= 5)
                        {
                            MessageBox.Show($"Tu membresía vence en {diasRestantes} días. ¡Renueva pronto!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró una membresía asociada al usuario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

               
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
                MessageBox.Show($"Archivo {rutaArchivo} no encontrado.");
                return null;
            }

            var lineas = dataHandler.ReadAllLines(rutaArchivo);
            foreach (var linea in lineas)
            {
                string[] datos = linea.Split(',');
                if (datos.Length >= 6)
                {
                    string id = datos[0];
                    string nombre = datos[1];
                    string correo = datos[2];
                    string tipo = datos[3];
                    string usuarioArchivo = datos[4];
                    string contraseñaArchivo = datos[5];

                    if (usuarioArchivo == usuario && contraseñaArchivo == contraseña)
                    {
                        if (tipo == "Cliente")
                            return new Cliente(int.Parse(id), nombre, correo, contraseñaArchivo);
                        else if (tipo == "Entrenador")
                            return new Entrenador(int.Parse(id), nombre, correo, contraseñaArchivo, "PuntosFuertes"); // Ajustar según los datos
                    }
                }
            }
            return null;
        }
    }
}
