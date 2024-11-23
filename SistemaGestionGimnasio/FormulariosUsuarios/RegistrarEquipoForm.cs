using SistemaGestionGimnasio.Modelos;
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

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class RegistrarEquipoForm : Form
    {
        private string usuarioActual;
        public RegistrarEquipoForm(string usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;

        }

            private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(TxtNombreEquipo.Text) ||
                string.IsNullOrWhiteSpace(CmbCategoria.Text) ||
                string.IsNullOrWhiteSpace(TxtVidaUtil.Text) ||
                string.IsNullOrWhiteSpace(CmbEstado.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Obtener los valores ingresados
            string nombreEquipo = TxtNombreEquipo.Text.Trim();
            string categoria = CmbCategoria.Text.Trim();
            string fechaAdquisicion = DtpFechaAdquisicion.Value.ToString("dd/MM/yyyy");
            string vidaUtil = TxtVidaUtil.Text.Trim();
            string estado = CmbEstado.Text.Trim();

            // Incluir el usuarioActual al guardar en el archivo
            string rutaArchivo = "inventario.csv";
            try
            {
                using (StreamWriter escritor = new StreamWriter(rutaArchivo, true))
                {
                    escritor.WriteLine($"{nombreEquipo},{categoria},{fechaAdquisicion},{vidaUtil},{estado},{usuarioActual}");
                }
                MessageBox.Show("Equipo registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los campos
                TxtNombreEquipo.Clear();
                CmbCategoria.SelectedIndex = -1;
                TxtVidaUtil.Clear();
                CmbEstado.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void GuardarEquipoEnArchivo(Inventario equipo)
        {
            string rutaArchivo = "inventario.csv";

            // Guardar los datos del objeto `Inventario` en el archivo CSV
            using (StreamWriter escritor = new StreamWriter(rutaArchivo, true))
            {
                escritor.WriteLine($"{equipo.NombreEquipo},{equipo.Categoria},{equipo.FechaAdquisicion:dd/MM/yyyy},{equipo.VidaUtilEstimada},{equipo.Estado}");
            }
        }
        private void RegistrarEquipoForm_Load(object sender, EventArgs e)
        {
            CmbCategoria.Items.AddRange(new string[] { "Electrónico", "Mecánico", "Otro" });
            CmbEstado.Items.AddRange(new string[] { "Activo", "Inactivo" });
        }


    }
}

