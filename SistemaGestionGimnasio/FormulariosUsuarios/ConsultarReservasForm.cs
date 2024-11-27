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
using SistemaGestionGimnasio.DataHandler;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class ConsultarReservasForm : Form
    {
        private readonly IDataHandler dataHandler;
        private readonly string usuarioActual;
        
        public ConsultarReservasForm(IDataHandler handler, string usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            dataHandler = handler;
        }

        private void ConsultarReservasForm_Load(object sender, EventArgs e)
        {
            TxtUsuario.Text = $"Reservas para: {usuarioActual}";
            CargarReservasCliente(usuarioActual);
        }

        private void CargarReservasCliente(string usuario)
        {
            string rutaArchivo = "Assets/reservas.csv";

            DgvReservasClientes.Rows.Clear();

            if (!dataHandler.FileExists(rutaArchivo))
            {
                MessageBox.Show("No se encontraron reservas registradas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                foreach (var linea in dataHandler.ReadAllLines(rutaArchivo))
                {
                    string[] datos = linea.Split(',');
                    if (datos.Length >= 3 && datos[2] == usuario)
                    {
                        DgvReservasClientes.Rows.Add(datos[0], datos[1]); // Añade los datos al DataGridView
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las reservas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnConsultarReservas_Click(object sender, EventArgs e)
        {
            ConsultarReservasForm reservasForm = new ConsultarReservasForm(dataHandler, usuarioActual);
            reservasForm.Show();
        }
    }
}
