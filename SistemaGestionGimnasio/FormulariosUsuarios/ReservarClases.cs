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


    }
}
