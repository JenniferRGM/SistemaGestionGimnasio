using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SistemaGestionGimnasio.Modelos;
using SistemaGestionGimnasio.FormulariosUsuarios;

namespace SistemaGestionGimnasio.Vistas
{
    public partial class UsuarioForm : Form
    {
        private string usuarioActual;
        public UsuarioForm(string usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            this.Load += new EventHandler(UsuarioForm_Load);
        }

        private void UsuarioForm_Load(object sender, EventArgs e)
        {
            // Muestra solo el panel de Inicio al abrir el formulario
            LblUsuario.Text = $"Bienvenido, {usuarioActual}";
            panelInicio.Visible = true;
           
        }
        // Método para abrir el formulario de registro de usuario
        private void RegistrarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarUsuarioForm registrarForm = new RegistrarUsuarioForm();
            registrarForm.Show(); // Abre el formulario de registro de usuario
        }

        // Método para abrir el formulario de modificación de usuario
        private void ModificarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarUsuarioForm modificarForm = new ModificarUsuarioForm();
            modificarForm.ShowDialog(); // Abre el formulario de modificación de usuario
        }

        // Método para abrir el formulario de consulta de usuarios
        private void ConsultarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarUsuarioForm consultarForm = new ConsultarUsuarioForm();
            consultarForm.Show(); // Abre el formulario de consulta de usuarios

        }

        // Método para abrir el formulario de eliminación de usuario
        private void EliminarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarUsuarioForm eliminarForm = new EliminarUsuarioForm();
            eliminarForm.Show(); // Abre el formulario de eliminación de usuario
        }

        private void HorariosPuntosFuertesEntrenadores_Click(object sender, EventArgs e)
        {
            AsignarHorariosPuntosFuertesForm asignarForm = new AsignarHorariosPuntosFuertesForm();
            asignarForm.Show();
        }

        private void AdministrarMembresíasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdministrarMembresiasForm adminForm = new AdministrarMembresiasForm();
            adminForm.Show();
        }

        private void ConsultarMembresíasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarMembresiasForm consultaForm = new ConsultarMembresiasForm();
            consultaForm.Show();
        }

        private void ReservarClasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReservarClases reservarClasesForm = new ReservarClases();
            reservarClasesForm.Show();
        }

        private void eliminarClasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarClasesForm eliminarClasesForm = new EliminarClasesForm(usuarioActual);
            eliminarClasesForm.Show();
        }

        private void registrarEquipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarEquipoForm registrarEquipoForm = new RegistrarEquipoForm(usuarioActual);
            registrarEquipoForm.Show();
        }

        private void consultarInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarInventarioForm consultarInventarioForm = new ConsultarInventarioForm();
            consultarInventarioForm.Show();
        }

        private void notificacionesDeMantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotificacionesMantenimientoForm mantenimientoForm = new NotificacionesMantenimientoForm();
            mantenimientoForm.Show();
        }
    }
}

