using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SistemaGestionGimnasio.Modelos;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class ReservarClases : Form

    {

        private string rutaArchivo = Path.Combine("Assets", "actividades.csv");

        public ReservarClases()
        {
            InitializeComponent();
            this.Load += new EventHandler(ReservarClasesForm_Load);
        }

        private void ReservarClasesForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("El archivo de actividades no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var clasesDisponibles = Clases.CargarClasesDesdeArchivo(rutaArchivo);

            foreach (var clase in clasesDisponibles)
            {
                CmbClases.Items.Add(clase);
            }
        }

        private void BtnReservar_Click(object sender, EventArgs e)
        {
            try
            {
                string claseSeleccionada = CmbClases.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(claseSeleccionada))
                {
                    MessageBox.Show("Por favor, selecciona una clase.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var partes = claseSeleccionada.Split('-');
                if (partes.Length < 4)
                {
                    MessageBox.Show("Formato de clase no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string nombreClase = partes[0].Trim();
                string fechaClase = partes[1].Trim();
                string horarioClase = partes[2].Trim();
                string entrenadorClase = partes[3].Split('(')[0].Trim();

                // Verifica los datos extraídos
                Console.WriteLine($"Clase seleccionada: Nombre={nombreClase}, Fecha={fechaClase}, Horario={horarioClase}, Entrenador={entrenadorClase}");

                Clases.ReservarClase(rutaArchivo, nombreClase, horarioClase, entrenadorClase, fechaClase);

                MessageBox.Show("Reserva realizada con éxito.", "Reserva completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show($"Error al reservar la clase: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"Error al reservar la clase: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}




