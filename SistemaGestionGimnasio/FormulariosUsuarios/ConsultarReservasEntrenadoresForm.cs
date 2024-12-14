using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaGestionGimnasio.DataHandler;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class ConsultarReservasEntrenadoresForm : Form
    {
        private readonly IDataHandler dataHandler;
        public ConsultarReservasEntrenadoresForm(IDataHandler dataHandler)
        {
            InitializeComponent();
            this.dataHandler = dataHandler;
        }
        private void ConsultarReservasEntrenadoresForm_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarClasesDelEntrenador(); 
        }
        private void ConfigurarDataGridView()
        {
            DgvReservas.Columns.Clear();
            DgvReservas.Columns.Add("Cliente", "Cliente");
            DgvReservas.Columns.Add("Fecha", "Fecha (DD/MM/YYYY)");
        }
        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            string claseSeleccionada = CmbClases.SelectedItem?.ToString();
            DateTime fechaSeleccionada = DtpFecha.Value.Date;

            if (string.IsNullOrWhiteSpace(claseSeleccionada))
            {
                MessageBox.Show("Por favor selecciona una clase.");
                return;
            }

            CargarReservasParaEntrenador(claseSeleccionada, fechaSeleccionada);
        }

        private void CargarReservasParaEntrenador(string clase, DateTime fecha)
        {
            string rutaArchivo = "Assets/reservas.csv";
            DgvReservas.Rows.Clear();

            if (dataHandler.FileExists(rutaArchivo))
            {
                MessageBox.Show("No se encontraron reservas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
                try
                {
                string formatoFecha = "dd/MM/yyyy";
                foreach (var linea in dataHandler.ReadAllLines(rutaArchivo))
                    {
                        string[] datos = linea.Split(',');
                        

                        if (datos.Length > 2 && datos[0].Trim() == clase &&
                            DateTime.TryParseExact(datos[1].Trim(), formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaArchivo) &&
                            fechaArchivo.Date == fecha.Date)
                        {
                            DgvReservas.Rows.Add(datos[2].Trim(), datos[1].Trim()); 
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar las reservas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void CargarClasesDelEntrenador()
        {
            string entrenadorActual = "Entrenador"; // Reemplaza con el nombre del entrenador actual
            string rutaArchivo = "Assets/ClasesEntrenadores.csv";

            if (!dataHandler.FileExists(rutaArchivo))
            {
                MessageBox.Show("No se encontraron clases para el entrenador.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                foreach (var linea in dataHandler.ReadAllLines(rutaArchivo))
                {
                    string[] datos = linea.Split(',');

                    // Valida que la línea tenga al menos dos columnas y coincida con el entrenador actual
                    if (datos.Length > 1 && datos[1].Trim() == entrenadorActual)
                    {
                        CmbClases.Items.Add(datos[0].Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las clases: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}




