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

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class ConsultarReservasEntrenadoresForm : Form
    {
        public ConsultarReservasEntrenadoresForm()
        {
            InitializeComponent();
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
            string rutaArchivo = "reservas.csv";

            DgvReservas.Rows.Clear();

            if (File.Exists(rutaArchivo))
            {
                using (StreamReader lector = new StreamReader(rutaArchivo))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {
                        string[] datos = linea.Split(',');
                        string formatoFecha = "dd/MM/yyyy";
                        if(datos.Length > 2 && datos[0] == clase && DateTime.TryParseExact(datos[1], formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaArchivo) && fechaArchivo.Date == fecha.Date)
                        {

                            DgvReservas.Rows.Add(datos[2], datos[1]); 
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontraron reservas.");

            }
        }

        private void ConsultarReservasEntrenadoresForm_Load(object sender, EventArgs e)
        {
            string entrenadorActual = "Entrenador";
            string rutaArchivo = "ClasesEntrenadores.csv";

            if (File.Exists(rutaArchivo))
            {
                using (StreamReader lector = new StreamReader(rutaArchivo))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {
                        string[] datos = linea.Split(',');
                        if (datos[1] == entrenadorActual)
                        {
                            CmbClases.Items.Add(datos[0]);
                        }
                    }
                }
            }
        }
    }
}

      

