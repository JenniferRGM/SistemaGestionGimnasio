namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    partial class RegistrarEquipoForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNombreEquipo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbCategoria = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DtpFechaAdquisicion = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtVidaUtil = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbEstado = new System.Windows.Forms.ComboBox();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(231, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registrar Equipo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-1, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre del equipo: ";
            // 
            // TxtNombreEquipo
            // 
            this.TxtNombreEquipo.Location = new System.Drawing.Point(253, 87);
            this.TxtNombreEquipo.Name = "TxtNombreEquipo";
            this.TxtNombreEquipo.Size = new System.Drawing.Size(216, 22);
            this.TxtNombreEquipo.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-1, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 31);
            this.label3.TabIndex = 3;
            this.label3.Text = "Categoría: ";
            // 
            // CmbCategoria
            // 
            this.CmbCategoria.FormattingEnabled = true;
            this.CmbCategoria.Location = new System.Drawing.Point(142, 140);
            this.CmbCategoria.Name = "CmbCategoria";
            this.CmbCategoria.Size = new System.Drawing.Size(207, 24);
            this.CmbCategoria.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(259, 31);
            this.label4.TabIndex = 5;
            this.label4.Text = "Fecha de adquisición: ";
            // 
            // DtpFechaAdquisicion
            // 
            this.DtpFechaAdquisicion.Location = new System.Drawing.Point(268, 198);
            this.DtpFechaAdquisicion.Name = "DtpFechaAdquisicion";
            this.DtpFechaAdquisicion.Size = new System.Drawing.Size(265, 22);
            this.DtpFechaAdquisicion.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(226, 31);
            this.label5.TabIndex = 7;
            this.label5.Text = "Vida útil estimada:";
            // 
            // TxtVidaUtil
            // 
            this.TxtVidaUtil.Location = new System.Drawing.Point(234, 265);
            this.TxtVidaUtil.Name = "TxtVidaUtil";
            this.TxtVidaUtil.Size = new System.Drawing.Size(246, 22);
            this.TxtVidaUtil.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 31);
            this.label6.TabIndex = 9;
            this.label6.Text = "Estado:";
            // 
            // CmbEstado
            // 
            this.CmbEstado.FormattingEnabled = true;
            this.CmbEstado.Location = new System.Drawing.Point(109, 318);
            this.CmbEstado.Name = "CmbEstado";
            this.CmbEstado.Size = new System.Drawing.Size(194, 24);
            this.CmbEstado.TabIndex = 10;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.BackColor = System.Drawing.Color.SkyBlue;
            this.BtnGuardar.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.Location = new System.Drawing.Point(339, 359);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(141, 51);
            this.BtnGuardar.TabIndex = 11;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // RegistrarEquipoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.CmbEstado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtVidaUtil);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DtpFechaAdquisicion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CmbCategoria);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtNombreEquipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegistrarEquipoForm";
            this.Text = "RegistrarEquipoForm";
            this.Load += new System.EventHandler(this.RegistrarEquipoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtNombreEquipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbCategoria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DtpFechaAdquisicion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtVidaUtil;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbEstado;
        private System.Windows.Forms.Button BtnGuardar;
    }
}