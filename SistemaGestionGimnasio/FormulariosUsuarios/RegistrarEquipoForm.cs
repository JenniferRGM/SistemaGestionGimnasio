using SistemaGestionGimnasio.DataHandler;
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
        private IDataHandler dataHandler;
        private Usuario usuarioActual;
        public RegistrarEquipoForm(Usuario usuario, IDataHandler handler)
        {
            InitializeComponent();
            usuarioActual = usuario;
            this.dataHandler = handler;

        }
            private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNombreEquipo.Text) ||
                string.IsNullOrWhiteSpace(CmbCategoria.Text) ||
                string.IsNullOrWhiteSpace(TxtVidaUtil.Text) ||
                string.IsNullOrWhiteSpace(CmbEstado.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            string nombreEquipo = TxtNombreEquipo.Text.Trim();
            string categoria = CmbCategoria.Text.Trim();
            string fechaAdquisicion = DtpFechaAdquisicion.Value.ToString("dd/MM/yyyy");
            string vidaUtil = TxtVidaUtil.Text.Trim();
            string estado = CmbEstado.Text.Trim();

            
            string nuevaLinea = $"{nombreEquipo},{categoria},{fechaAdquisicion},{vidaUtil},{estado},{usuarioActual.Nombre}";

            try
            {
                
                dataHandler.AppendLine("inventario.csv", nuevaLinea);

                MessageBox.Show("Equipo registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
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
     
        private void RegistrarEquipoForm_Load(object sender, EventArgs e)
        {
            CmbCategoria.Items.AddRange(new string[] { "Electrónico", "Mecánico", "Otro" });
            CmbEstado.Items.AddRange(new string[] { "Activo", "Inactivo" });
        }


    }
}

