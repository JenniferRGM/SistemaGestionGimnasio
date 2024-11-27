using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SistemaGestionGimnasio.Modelos;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class ReservarClases : Form

    {
        
        private string rutaArchivo = Path.Combine("Assets", "clases.csv");

        public ReservarClases()
        {
            InitializeComponent();
            
        }

        private void ReservarClasesForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("El archivo de clases no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var clasesDisponibles = Clases.CargarClasesDesdeArchivo(rutaArchivo);

            foreach (var clase in clasesDisponibles)
            {
                CmbClases.Items.Add(clase.Nombre);
            }
        }

        private void BtnReservar_Click(object sender, EventArgs e)
        {
            string nombreClase = CmbClases.SelectedItem?.ToString();
            DateTime fechaSeleccionada = DtpFecha.Value.Date;

            if (string.IsNullOrEmpty(nombreClase))
            {
                MessageBox.Show("Por favor, selecciona una clase.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("El archivo de clases no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cupoActual = Clases.ObtenerCupoActual(rutaArchivo, nombreClase, fechaSeleccionada);

            if (cupoActual >= 20)
            {
                MessageBox.Show("El cupo para esta clase y hora está lleno. Por favor, selecciona otra clase u horario.", "Cupo lleno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Clases.ReservarClase(rutaArchivo, nombreClase, fechaSeleccionada);

            MessageBox.Show("Reserva realizada con éxito.", "Reserva completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}




