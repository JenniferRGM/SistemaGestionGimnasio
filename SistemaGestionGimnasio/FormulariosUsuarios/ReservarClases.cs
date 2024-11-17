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
using SistemaGestionGimnasio.Modelos;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class ReservarClases : Form
    {

        public ReservarClases()
        {
            InitializeComponent();

        }

        private void ReservarClasesForm_Load(object sender, EventArgs e)
        {
            string rutaArchivo = "clases.csv";
            var clases = Clases.CargarClasesDesdeArchivo(rutaArchivo);

            foreach (var clase in clases)
            {
                CmbClases.Items.Add(clase.Nombre);
            }
        }

        private void BtnReservar_Click(object sender, EventArgs e)
        {
            string nombreClase = CmbClases.SelectedItem?.ToString();
            DateTime fecha = DtpFecha.Value.Date;

            if (!string.IsNullOrEmpty(nombreClase))
            {
                string rutaArchivo = "clases.csv";
                int cupoActual = Clases.ObtenerCupoActual(rutaArchivo, nombreClase, fecha);

                if (cupoActual >= 20)
                {
                    MessageBox.Show("El cupo para esta clase y hora está lleno. Por favor, selecciona otra clase u horario.", "Cupo lleno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Clases.ReservarClase(rutaArchivo, nombreClase, fecha);
                    MessageBox.Show("Reserva realizada con éxito.", "Reserva completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una clase.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static void ActualizarCupo(string clase)
        {
            string rutaArchivo = "clases.csv";
            var clasesActualizadas = new List<string>();

            if (File.Exists(rutaArchivo))
            {
                using (StreamReader lector = new StreamReader(rutaArchivo))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {
                        string[] datos = linea.Split(',');
                        if (datos[0] == clase)
                        {
                            int capacidad = int.Parse(datos[1]);
                            capacidad--; // Reducir el cupo en 1
                            clasesActualizadas.Add($"{datos[0]},{capacidad}");
                        }
                        else
                        {
                            clasesActualizadas.Add(linea);
                        }
                    }
                }

                using (StreamWriter escritor = new StreamWriter(rutaArchivo))
                {
                    foreach (var claseActualizada in clasesActualizadas)
                    {
                        escritor.WriteLine(claseActualizada);
                    }
                }

            }
        }
    }
}
