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

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class ConsultarReservasForm : Form
    {
        private string usuarioActual;
        public ConsultarReservasForm(string usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void ConsultarReservasForm_Load(object sender, EventArgs e)
        {
            TxtUsuario.Text = $"Reservas para: {usuarioActual}";
            CargarReservasCliente(usuarioActual);
        }

        private void CargarReservasCliente(string usuario)
        {
            string rutaArchivo = "reservas.csv";

            DgvReservasClientes.Rows.Clear();

            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("No se encontraron reservas registradas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    string[] datos = linea.Split(',');
                    if (datos.Length >= 3 && datos[2] == usuario)
                    {
                        DgvReservasClientes.Rows.Add(datos[0], datos[1]);
                    }
                }
            }
        }

        private void BtnConsultarReservas_Click(object sender, EventArgs e)
        {
            ConsultarReservasForm reservasForm = new ConsultarReservasForm(usuarioActual);
            reservasForm.Show();
        }
    }
}
