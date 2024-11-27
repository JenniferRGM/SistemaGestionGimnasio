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
using SistemaGestionGimnasio.Vistas;
using SistemaGestionGimnasio.DataHandler;
using System.Runtime.InteropServices;


namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class AdministrarMembresiasForm : Form
    {
        private readonly IDataHandler dataHandler;

        public AdministrarMembresiasForm(IDataHandler handler)
        {
            InitializeComponent();
            dataHandler = handler;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            DateTime fechaInicio = dtpFechaInicio.Value;
            DateTime fechaVencimiento = dtpFechaVencimiento.Value;

            string rutaArchivo = Path.Combine("Assets", "membresias.csv");

            string nuevaLinea = $"{usuario},{fechaInicio:dd/MM/yyyy},{fechaVencimiento:dd/MM/yyyy}";
            dataHandler.AppendLine(rutaArchivo, nuevaLinea);

            MessageBox.Show("Membresía agregada correctamente.");
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            txtUsuario.Clear();
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaVencimiento.Value = DateTime.Now.AddMonths(1);
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            DateTime fechaInicio = dtpFechaInicio.Value;
            DateTime fechaVencimiento = dtpFechaVencimiento.Value;

            string rutaArchivo = Path.Combine("Assets", "membresias.csv");
            string rutaTemporal = Path.Combine("Assets", "temp_membresias.csv");

            if (!dataHandler.FileExists(rutaArchivo))
            {
                MessageBox.Show("El archivo de membresías no existe.");
                return;
            }

            bool encontrado = false;
            var lineasActualizadas = new List<string>();

            foreach (var linea in dataHandler.ReadAllLines(rutaArchivo))
            {
                string[] datos = linea.Split(',');

                if (datos.Length >= 3 && datos[0].Trim() == usuario)
                {
                    string nuevaLinea = $"{usuario},{fechaInicio:yyyy-MM-dd},{fechaVencimiento:yyyy-MM-dd}";
                    lineasActualizadas.Add(nuevaLinea);
                    encontrado = true;
                }
                else
                {
                    lineasActualizadas.Add(linea);
                }
            }

            dataHandler.WriteAllLines(rutaTemporal, lineasActualizadas.ToArray());
            dataHandler.DeleteFile(rutaArchivo);
            dataHandler.MoveFile(rutaTemporal, rutaArchivo);

            if (encontrado)
            {
                MessageBox.Show("Membresía actualizada con éxito.");
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Usuario no encontrado.");
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();

            string rutaArchivo = Path.Combine("Assets", "membresias.csv");
            string rutaTemporal = Path.Combine("Assets", "temp_membresias.csv");

            if (!dataHandler.FileExists(rutaArchivo))
            {
                MessageBox.Show("El archivo de membresías no existe.");
                return;
            }

            var lineas = dataHandler.ReadAllLines(rutaArchivo);
            var lineasActualizadas = new List<string>();
            bool encontrado = false;

            foreach (var linea in lineas)
            {
                var datos = linea.Split(',');

                if (datos.Length >= 3 && datos[0].Trim() == usuario)
                {
                    // Salta la línea del usuario
                    encontrado = true;
                    continue;
                }

                lineasActualizadas.Add(linea);
            }

            DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que deseas eliminar esta membresía?", "Confirmar Eliminación", MessageBoxButtons.YesNo);
            if (confirmacion == DialogResult.No) return;

            if (!encontrado)
            {
                MessageBox.Show("Usuario no encontrado.");
                return;
            }

            // Escribe las líneas actualizadas
            dataHandler.WriteAllLines(rutaTemporal, lineasActualizadas.ToArray());
            dataHandler.DeleteFile(rutaArchivo);
            dataHandler.MoveFile(rutaTemporal, rutaArchivo);

            MessageBox.Show("Membresía eliminada con éxito.");
            LimpiarCampos();
        }

    }
}


