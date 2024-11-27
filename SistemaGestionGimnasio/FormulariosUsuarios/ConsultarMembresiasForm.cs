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
using SistemaGestionGimnasio.DataHandler;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class ConsultarMembresiasForm : Form
    {
        private readonly IDataHandler dataHandler;
        public ConsultarMembresiasForm(IDataHandler dataHandler)
        {
            InitializeComponent();
            CargarMembresias();
            this.dataHandler = dataHandler;
        }

        private void CargarMembresias()
        {
            string rutaArchivo = "Assets/membresias.csv"; // Ruta relativa al archivo

            if (!dataHandler.FileExists(rutaArchivo)) // Verifica si el archivo existe usando IDataHandler
            {
                MessageBox.Show("No se encontró el archivo de membresías.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DgvMembresias.Rows.Clear(); 

            try
            {
                foreach (var linea in dataHandler.ReadAllLines(rutaArchivo)) 
                {
                    string[] datos = linea.Split(',');
                    if (datos.Length >= 3)
                    {
                        string usuario = datos[0];
                        string fechaVencimientoString = datos[2];
                        string estado = "Desconocido";

                        if (DateTime.TryParseExact(datos[2], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaVencimiento))
                        {
                            int diasRestantes = (fechaVencimiento - DateTime.Now).Days;
                            estado = diasRestantes <= 5 ? "Por vencer" : "Activa";
                        }
                        else
                        {
                            MessageBox.Show($"El formato de la fecha '{fechaVencimientoString}' no es válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        // Agrega la fila incluso si la fecha no fue válida para mostrar los datos restantes
                        DgvMembresias.Rows.Add(usuario, datos[1], fechaVencimientoString, estado);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las membresías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarMembresias();
        }
    }
}


