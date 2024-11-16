using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Globalization;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class ConsultarMembresiasForm : Form
    {
        public ConsultarMembresiasForm()
        {
            InitializeComponent();
            CargarMembresias();
        }

        private void CargarMembresias()
        {
            string rutaArchivo = "membresias.csv";

            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("No se encontró el archivo de membresías.");
                return;
            }

            DgvMembresias.Rows.Clear(); // Limpia las filas existentes

            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    string[] datos = linea.Split(',');
                    if (datos.Length >= 3)
                    {
                        string usuario = datos[0];
                        string fechaVencimientoString = datos[2];
                        string estado = "Desconocido";

                        if (DateTime.TryParseExact(datos[2], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime fechaVencimiento))
                        {
                            int diasRestantes = (fechaVencimiento - DateTime.Now).Days;
                            estado = diasRestantes <= 5 ? "Por vencer" : "Activa";
                        }
                        else
                        {
                            MessageBox.Show($"El formato de la fecha '{fechaVencimientoString}' no es válido.");
                        }

                        // Agrega la fila incluso si la fecha no fue válida para mostrar los datos restantes
                        DgvMembresias.Rows.Add(usuario, datos[1], fechaVencimientoString, estado);
                    }
                }
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarMembresias();
        }
    }
}


