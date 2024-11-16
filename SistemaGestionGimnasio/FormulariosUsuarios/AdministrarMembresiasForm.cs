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


namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class AdministrarMembresiasForm : Form
    {
        public AdministrarMembresiasForm()
        {
            InitializeComponent();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            DateTime fechaInicio = dtpFechaInicio.Value;
            DateTime fechaVencimiento = dtpFechaVencimiento.Value;

            string rutaArchivo = "membresias.csv";
            using (StreamWriter escritor = new StreamWriter(rutaArchivo, true))
            {
                escritor.WriteLine($"{usuario},{fechaInicio:dd/MM/yyyy},{fechaVencimiento:dd/MM/yyyy}");
            }

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

            string rutaArchivo = "membresias.csv";
            string rutaTemporal = "temp_membresias.csv";

            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("El archivo de membresías no existe.");
                return;
            }

            bool encontrado = false;

            using (StreamReader lector = new StreamReader(rutaArchivo))
            using (StreamWriter escritor = new StreamWriter(rutaTemporal))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    string[] datos = linea.Split(',');

                    if (datos.Length >= 3 && datos[0].Trim() == usuario)
                    {
                        // Actualizar la información
                        string nuevaLinea = $"{usuario},{fechaInicio:yyyy-MM-dd},{fechaVencimiento:yyyy-MM-dd}";
                        escritor.WriteLine(nuevaLinea);
                        encontrado = true;
                    }
                    else
                    {
                        // Copiar línea original
                        escritor.WriteLine(linea);
                    }
                }
            }

            // Reemplazar el archivo original
            File.Delete(rutaArchivo);
            File.Move(rutaTemporal, rutaArchivo);

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

            string rutaArchivo = "membresias.csv";
            string rutaTemporal = "temp_membresias.csv";

            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("El archivo de membresías no existe.");
                return;
            }

            bool encontrado = false;

            using (StreamReader lector = new StreamReader(rutaArchivo))
            using (StreamWriter escritor = new StreamWriter(rutaTemporal))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    string[] datos = linea.Split(',');

                    if (datos.Length >= 3 && datos[0].Trim() == usuario)
                    {
                        // Salta la línea que coincide con el usuario (eliminar)
                        encontrado = true;
                        continue;
                    }

                    escritor.WriteLine(linea);
                }
            }
            DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que deseas eliminar esta membresía?", "Confirmar Eliminación", MessageBoxButtons.YesNo);
            if (confirmacion == DialogResult.No) return;

            // Reemplaza el archivo original
            File.Delete(rutaArchivo);
            File.Move(rutaTemporal, rutaArchivo);

            if (encontrado)
            {
                MessageBox.Show("Membresía eliminada con éxito.");
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Usuario no encontrado.");
            }
        }

    }
}


