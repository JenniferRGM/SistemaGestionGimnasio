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
using SistemaGestionGimnasio.DataHandler;


namespace SistemaGestionGimnasio.Vistas
{
    public partial class UsuarioForm : Form
    {
        private Usuario usuarioActual;
        public UsuarioForm(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            ConfigurarMenus();
            this.Load += new EventHandler(UsuarioForm_Load);
        }


        private void ConfigurarMenus()
        {
            MessageBox.Show($"El tipo de usuario actual es: {usuarioActual.Tipo}", "Depuración");

            if (usuarioActual.Tipo == "Cliente")
            {
                ConfigurarMenuCliente();
            }
            else if (usuarioActual.Tipo == "Entrenador")
            {
                ConfigurarMenuEntrenador();
            }
            else
            {
                MessageBox.Show("Tipo de usuario no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarMenuCliente()
        {
            // Mostrar opciones para cliente
            ModificarUsuarioToolStripMenuItem.Visible = true;
            ConsultarClaseToolStripMenuItem.Visible = true;
            consultarReservasToolStripMenuItem.Visible = true;
            reservarClasesToolStripMenuItem.Visible = true;
            eliminarClasesToolStripMenuItem.Visible = true;
            ConsultarMembresíasToolStripMenuItem.Visible = true;

            // Ocultar opciones no aplicables a cliente
            gestiónDeFacturasToolStripMenuItem.Visible = false;
            AdministrarMembresíasToolStripMenuItem.Visible = false;
            ActualizarCupoToolStripMenuItem.Visible = false;
            consultarReservasEntrenadoresToolStripMenuItem.Visible = false;
            reportesDeCrecimientosDeMembresíasToolStripMenuItem.Visible = false;
            registrarEquipoToolStripMenuItem.Visible = false;
            consultarInventarioToolStripMenuItem.Visible = false;
            notificacionesDeMantenimientoToolStripMenuItem.Visible = false;
            reporteDeMatrículaToolStripMenuItem.Visible = false;
            informeContableToolStripMenuItem.Visible = false;
            reporteDeClasesPopularesToolStripMenuItem.Visible = false;
            RegistrarUsuarioToolStripMenuItem.Visible = false;
            ConsultarUsuariosToolStripMenuItem.Visible = false;
            EliminarUsuariosToolStripMenuItem.Visible = false;
            horariosYPuntosFuertesEntrenadoresToolStripMenuItem.Visible = false;
        }

        private void ConfigurarMenuEntrenador()
        {
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.Visible = true;
            }
        }

        private void UsuarioForm_Load(object sender, EventArgs e)
        {
            // Muestra solo el panel de Inicio al abrir el formulario
            
            panelInicio.Visible = true;
           
        }
        // Método para abrir el formulario de registro de usuario
        private void RegistrarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataHandler dataHandler = new FileDataHandler();
            RegistrarUsuarioForm registrarUsuarioForm = new RegistrarUsuarioForm(dataHandler);
            registrarUsuarioForm.Show();
        }

        // Método para abrir el formulario de consulta de usuarios
        private void ConsultarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataHandler dataHandler = new FileDataHandler();
            ConsultarUsuarioForm form = new ConsultarUsuarioForm(dataHandler);
            form.Show();

        }

        // Método para abrir el formulario de eliminación de usuario
        private void EliminarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataHandler dataHandler = new FileDataHandler();
            EliminarUsuarioForm eliminarForm = new EliminarUsuarioForm(dataHandler);
            eliminarForm.Show();

        }

        private void HorariosPuntosFuertesEntrenadores_Click(object sender, EventArgs e)
        {
            IDataHandler dataHandler = new FileDataHandler();
            AsignarHorariosPuntosFuertesForm form = new AsignarHorariosPuntosFuertesForm(dataHandler);
            form.Show();
        }

        private void AdministrarMembresíasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataHandler dataHandler = new FileDataHandler();
            AdministrarMembresiasForm form = new AdministrarMembresiasForm(dataHandler);
            form.Show();
        }

        private void ConsultarMembresíasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dataHandler = new FileDataHandler();
            var formulario = new ConsultarMembresiasForm(dataHandler);
            formulario.Show();
        }

        private void ReservarClasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ReservarClases reservarClasesForm = new ReservarClases();
            reservarClasesForm.Show(); 
        }

        private void eliminarClasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataHandler dataHandler = new FileDataHandler(); 
            EliminarClasesForm form = new EliminarClasesForm(usuarioActual, dataHandler);
            form.Show();

        }

        private void registrarEquipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataHandler dataHandler = new FileDataHandler();
            RegistrarEquipoForm registrarEquipoForm = new RegistrarEquipoForm(usuarioActual, dataHandler);
            registrarEquipoForm.Show();
        }

        private void consultarInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataHandler dataHandler = new FileDataHandler();
            ConsultarInventarioForm form = new ConsultarInventarioForm(dataHandler);
            form.Show();
        }

        private void notificacionesDeMantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataHandler dataHandler = new FileDataHandler();
            NotificacionesMantenimientoForm mantenimientoForm = new NotificacionesMantenimientoForm(dataHandler);
            mantenimientoForm.Show();
        }

        private void reportesDeCrecimientosDeMembresíasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataHandler dataHandler = new FileDataHandler();
            ReporteCrecimientoForm reporteForm = new ReporteCrecimientoForm(dataHandler);
            reporteForm.Show();
        }

        private void reporteDeMatrículaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataHandler dataHandler = new FileDataHandler();
            CrecimientoMatriculaForm form = new CrecimientoMatriculaForm(dataHandler);
            form.Show();

        }

        private void informeContableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataHandler dataHandler = new FileDataHandler();
            InformeContableForm form = new InformeContableForm(dataHandler);
            form.Show();

        }

        private void ActualizarCupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataHandler dataHandler = new FileDataHandler();

            ActualizarCuposForm actualizarCuposForm = new ActualizarCuposForm(dataHandler);
            actualizarCuposForm.Show();

        }

        private void reporteDeClasesPopularesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataHandler dataHandler = new FileDataHandler();
            ClasesPopularesForm form = new ClasesPopularesForm(dataHandler);
            form.Show();
        }

        private void ConsultarClaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataHandler dataHandler = new FileDataHandler();
            ConsultarClasesForm form = new ConsultarClasesForm(dataHandler);
            form.Show();
        }

        private void consultarReservasEntrenadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataHandler dataHandler = new FileDataHandler();
            ConsultarReservasEntrenadoresForm form = new ConsultarReservasEntrenadoresForm(dataHandler);
            form.Show();

        }

        private void consultarReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataHandler dataHandler = new FileDataHandler();
            string usuarioActualLocal = "nombreUsuario";
            ConsultarReservasForm form = new ConsultarReservasForm(dataHandler, usuarioActualLocal);
            form.Show();
        }

        private void gestiónDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataHandler dataHandler = new FileDataHandler();
            GestionFacturasForm form = new GestionFacturasForm(dataHandler);
            form.Show();
        }

        private void ModificarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataHandler dataHandler = new FileDataHandler();
            ModificarUsuarioForm modificarForm = new ModificarUsuarioForm(dataHandler);
            modificarForm.ShowDialog();
        }
    }
}

