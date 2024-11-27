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

        // Método para cargar las clases al formulario al iniciar
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

        // Método para manejar el evento del botón Reservar
        private void BtnReservar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que haya una clase seleccionada
                string claseSeleccionada = CmbClases.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(claseSeleccionada))
                {
                    MessageBox.Show("Por favor, selecciona una clase.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Dividir los valores seleccionados en el combo box
                var partes = claseSeleccionada.Split('-');
                if (partes.Length < 4)
                {
                    MessageBox.Show("Formato de clase no válido. Por favor, verifica.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Extraer y limpiar los valores
                string nombreClase = partes[0].Trim().ToLower(); // Ejercicios funcionales
                string fechaClase = partes[1].Trim();           // 27/11/2024
                string horarioClase = partes[2].Split(':')[0].Trim(); // 5 (solo la hora inicial)
                string entrenadorClase = partes[3].Split('(')[0].Trim().ToLower(); // Andrea Mora Salas

                Console.WriteLine($"Clase seleccionada: Nombre={nombreClase}, Fecha={fechaClase}, Horario={horarioClase}, Entrenador={entrenadorClase}");

                // Llamar al método para realizar la reserva
                Clases.ReservarClase(rutaArchivo, nombreClase, horarioClase, entrenadorClase, fechaClase);

                MessageBox.Show("Reserva realizada con éxito.", "Reserva completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Actualizar lista de clases
                CargarClases();
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

        // Método para recargar las clases disponibles
        private void CargarClases()
        {
            CmbClases.Items.Clear();

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

            if (CmbClases.Items.Count > 0)
            {
                CmbClases.SelectedIndex = 0; // Seleccionar la primera opción por defecto
            }
        }
    }
}




