namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    partial class NotificacionesMantenimientoForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.DgvMantenimiento = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblNotificacion = new System.Windows.Forms.Label();
            this.BtnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMantenimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(160, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(486, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Notificaciones de Mantenimiento";
            // 
            // DgvMantenimiento
            // 
            this.DgvMantenimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMantenimiento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.DgvMantenimiento.Location = new System.Drawing.Point(24, 70);
            this.DgvMantenimiento.Name = "DgvMantenimiento";
            this.DgvMantenimiento.RowHeadersWidth = 51;
            this.DgvMantenimiento.RowTemplate.Height = 24;
            this.DgvMantenimiento.Size = new System.Drawing.Size(850, 185);
            this.DgvMantenimiento.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nombre Equipo";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Categoría";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Fecha Adquisición";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Vida Útil";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Estado";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // LblNotificacion
            // 
            this.LblNotificacion.AutoSize = true;
            this.LblNotificacion.Location = new System.Drawing.Point(56, 271);
            this.LblNotificacion.Name = "LblNotificacion";
            this.LblNotificacion.Size = new System.Drawing.Size(20, 16);
            this.LblNotificacion.TabIndex = 2;
            this.LblNotificacion.Text = "\" \"";
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.BackColor = System.Drawing.Color.SkyBlue;
            this.BtnActualizar.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizar.Location = new System.Drawing.Point(191, 333);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(399, 68);
            this.BtnActualizar.TabIndex = 3;
            this.BtnActualizar.Text = "Actualizar Notificaciones";
            this.BtnActualizar.UseVisualStyleBackColor = false;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // NotificacionesMantenimientoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(906, 526);
            this.Controls.Add(this.BtnActualizar);
            this.Controls.Add(this.LblNotificacion);
            this.Controls.Add(this.DgvMantenimiento);
            this.Controls.Add(this.label1);
            this.Name = "NotificacionesMantenimientoForm";
            this.Text = "NotificacionesMantenimientoForm";
            this.Load += new System.EventHandler(this.NotificacionesMantenimientoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMantenimiento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvMantenimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label LblNotificacion;
        private System.Windows.Forms.Button BtnActualizar;
    }
}