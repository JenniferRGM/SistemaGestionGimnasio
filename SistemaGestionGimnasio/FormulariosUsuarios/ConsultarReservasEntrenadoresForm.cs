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
                try
                {
                    foreach (var linea in dataHandler.ReadAllLines(rutaArchivo))
                    {
                        string[] datos = linea.Split(',');
                        string formatoFecha = "dd/MM/yyyy";

                        if (datos.Length > 2 && datos[0] == clase &&
                            DateTime.TryParseExact(datos[1], formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaArchivo) &&
                            fechaArchivo.Date == fecha.Date)
                        {
                            DgvReservas.Rows.Add(datos[2], datos[1]); 
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar las reservas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se encontraron reservas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ConsultarReservasEntrenadoresForm_Load(object sender, EventArgs e)
        {
            string entrenadorActual = "Entrenador";
            string rutaArchivo = "Assets/ClasesEntrenadores.csv";

            if (dataHandler.FileExists(rutaArchivo))
            {
                try
                {
                    foreach (var linea in dataHandler.ReadAllLines(rutaArchivo))
                    {
                        string[] datos = linea.Split(',');
                        if (datos.Length > 1 && datos[1] == entrenadorActual)
                        {
                            CmbClases.Items.Add(datos[0]); // Añadir la clase asociada al entrenador
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar las clases: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se encontraron clases para el entrenador.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}



