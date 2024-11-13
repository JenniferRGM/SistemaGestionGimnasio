namespace SistemaGestionGimnasio.Vistas
{
    partial class UsuarioForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RegistrarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModificarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConsultarUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EliminarUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarClaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservarClaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarReservasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.membresíasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarMembresíasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarMembresíasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarEquipoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarInventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificacionesDeMantenimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeMatrículaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informeContableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeClasesPopularesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelInicio = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.horariosYPuntosFuertesEntrenadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panelInicio.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.clasesToolStripMenuItem,
            this.membresíasToolStripMenuItem,
            this.inventarioToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(730, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RegistrarUsuarioToolStripMenuItem,
            this.ModificarUsuarioToolStripMenuItem,
            this.ConsultarUsuariosToolStripMenuItem,
            this.EliminarUsuariosToolStripMenuItem,
            this.horariosYPuntosFuertesEntrenadoresToolStripMenuItem});
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // RegistrarUsuarioToolStripMenuItem
            // 
            this.RegistrarUsuarioToolStripMenuItem.Name = "RegistrarUsuarioToolStripMenuItem";
            this.RegistrarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(281, 22);
            this.RegistrarUsuarioToolStripMenuItem.Text = "Registrar Usuario";
            this.RegistrarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.RegistrarUsuarioToolStripMenuItem_Click);
            // 
            // ModificarUsuarioToolStripMenuItem
            // 
            this.ModificarUsuarioToolStripMenuItem.Name = "ModificarUsuarioToolStripMenuItem";
            this.ModificarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(281, 22);
            this.ModificarUsuarioToolStripMenuItem.Text = "Modificar Usuario";
            this.ModificarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.ModificarUsuarioToolStripMenuItem_Click);
            // 
            // ConsultarUsuariosToolStripMenuItem
            // 
            this.ConsultarUsuariosToolStripMenuItem.Name = "ConsultarUsuariosToolStripMenuItem";
            this.ConsultarUsuariosToolStripMenuItem.Size = new System.Drawing.Size(281, 22);
            this.ConsultarUsuariosToolStripMenuItem.Text = "Consultar Usuarios";
            this.ConsultarUsuariosToolStripMenuItem.Click += new System.EventHandler(this.ConsultarUsuariosToolStripMenuItem_Click);
            // 
            // EliminarUsuariosToolStripMenuItem
            // 
            this.EliminarUsuariosToolStripMenuItem.Name = "EliminarUsuariosToolStripMenuItem";
            this.EliminarUsuariosToolStripMenuItem.Size = new System.Drawing.Size(281, 22);
            this.EliminarUsuariosToolStripMenuItem.Text = "Eliminar Usuarios";
            this.EliminarUsuariosToolStripMenuItem.Click += new System.EventHandler(this.EliminarUsuariosToolStripMenuItem_Click);
            // 
            // clasesToolStripMenuItem
            // 
            this.clasesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarClaseToolStripMenuItem,
            this.consultarToolStripMenuItem,
            this.reservarClaseToolStripMenuItem,
            this.consultarReservasToolStripMenuItem});
            this.clasesToolStripMenuItem.Name = "clasesToolStripMenuItem";
            this.clasesToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.clasesToolStripMenuItem.Text = "Clases";
            // 
            // registrarClaseToolStripMenuItem
            // 
            this.registrarClaseToolStripMenuItem.Name = "registrarClaseToolStripMenuItem";
            this.registrarClaseToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            // 
            // reservarClaseToolStripMenuItem
            // 
            this.reservarClaseToolStripMenuItem.Name = "reservarClaseToolStripMenuItem";
            this.reservarClaseToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            // 
            // consultarReservasToolStripMenuItem
            // 
            this.consultarReservasToolStripMenuItem.Name = "consultarReservasToolStripMenuItem";
            this.consultarReservasToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.consultarReservasToolStripMenuItem.Text = "Consultar Reservas";
            // 
            // membresíasToolStripMenuItem
            // 
            this.membresíasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarMembresíasToolStripMenuItem,
            this.consultarMembresíasToolStripMenuItem});
            this.membresíasToolStripMenuItem.Name = "membresíasToolStripMenuItem";
            this.membresíasToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.membresíasToolStripMenuItem.Text = "Membresías";
            // 
            // administrarMembresíasToolStripMenuItem
            // 
            this.administrarMembresíasToolStripMenuItem.Name = "administrarMembresíasToolStripMenuItem";
            this.administrarMembresíasToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.administrarMembresíasToolStripMenuItem.Text = "Administrar Membresías";
            // 
            // consultarMembresíasToolStripMenuItem
            // 
            this.consultarMembresíasToolStripMenuItem.Name = "consultarMembresíasToolStripMenuItem";
            this.consultarMembresíasToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.consultarMembresíasToolStripMenuItem.Text = "Consultar Membresías";
            // 
            // inventarioToolStripMenuItem
            // 
            this.inventarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarEquipoToolStripMenuItem,
            this.consultarInventarioToolStripMenuItem,
            this.notificacionesDeMantenimientoToolStripMenuItem});
            this.inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
            this.inventarioToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.inventarioToolStripMenuItem.Text = "Inventario";
            // 
            // registrarEquipoToolStripMenuItem
            // 
            this.registrarEquipoToolStripMenuItem.Name = "registrarEquipoToolStripMenuItem";
            this.registrarEquipoToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.registrarEquipoToolStripMenuItem.Text = "Registrar Equipo";
            // 
            // consultarInventarioToolStripMenuItem
            // 
            this.consultarInventarioToolStripMenuItem.Name = "consultarInventarioToolStripMenuItem";
            this.consultarInventarioToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.consultarInventarioToolStripMenuItem.Text = "Consultar Inventario";
            // 
            // notificacionesDeMantenimientoToolStripMenuItem
            // 
            this.notificacionesDeMantenimientoToolStripMenuItem.Name = "notificacionesDeMantenimientoToolStripMenuItem";
            this.notificacionesDeMantenimientoToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.notificacionesDeMantenimientoToolStripMenuItem.Text = "Notificaciones de Mantenimiento";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporteDeMatrículaToolStripMenuItem,
            this.informeContableToolStripMenuItem,
            this.reporteDeClasesPopularesToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // reporteDeMatrículaToolStripMenuItem
            // 
            this.reporteDeMatrículaToolStripMenuItem.Name = "reporteDeMatrículaToolStripMenuItem";
            this.reporteDeMatrículaToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.reporteDeMatrículaToolStripMenuItem.Text = "Reporte de Matrícula";
            // 
            // informeContableToolStripMenuItem
            // 
            this.informeContableToolStripMenuItem.Name = "informeContableToolStripMenuItem";
            this.informeContableToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.informeContableToolStripMenuItem.Text = "Informe Contable";
            // 
            // reporteDeClasesPopularesToolStripMenuItem
            // 
            this.reporteDeClasesPopularesToolStripMenuItem.Name = "reporteDeClasesPopularesToolStripMenuItem";
            this.reporteDeClasesPopularesToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.reporteDeClasesPopularesToolStripMenuItem.Text = "Reporte de Clases Populares";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // panelInicio
            // 
            this.panelInicio.BackColor = System.Drawing.Color.LightCyan;
            this.panelInicio.Controls.Add(this.textBox1);
            this.panelInicio.Controls.Add(this.label7);
            this.panelInicio.Location = new System.Drawing.Point(0, 25);
            this.panelInicio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelInicio.Name = "panelInicio";
            this.panelInicio.Size = new System.Drawing.Size(730, 357);
            this.panelInicio.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightCyan;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(174, 109);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(362, 84);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "\"Este sistema le permite gestionar usuarios, clases, inventario y reportes para u" +
    "n mejor control del gimnasio.\"";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(124, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(498, 36);
            this.label7.TabIndex = 0;
            this.label7.Text = "Bienvenido al Sistema de Gestión de Gimnasio";
            // 
            // horariosYPuntosFuertesEntrenadoresToolStripMenuItem
            // 
            this.horariosYPuntosFuertesEntrenadoresToolStripMenuItem.Name = "horariosYPuntosFuertesEntrenadoresToolStripMenuItem";
            this.horariosYPuntosFuertesEntrenadoresToolStripMenuItem.Size = new System.Drawing.Size(281, 22);
            this.horariosYPuntosFuertesEntrenadoresToolStripMenuItem.Text = "Horarios y Puntos Fuertes Entrenadores";
            // 
            // UsuarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 382);
            this.Controls.Add(this.panelInicio);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UsuarioForm";
            this.Text = "UsuarioForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelInicio.ResumeLayout(false);
            this.panelInicio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem membresíasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarClaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservarClaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarReservasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarMembresíasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarMembresíasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarEquipoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarInventarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notificacionesDeMantenimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeMatrículaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informeContableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeClasesPopularesToolStripMenuItem;
        private System.Windows.Forms.Panel panelInicio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RegistrarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ModificarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConsultarUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EliminarUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horariosYPuntosFuertesEntrenadoresToolStripMenuItem;
    }
}