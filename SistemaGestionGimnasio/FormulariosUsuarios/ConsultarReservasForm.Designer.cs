namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    partial class ConsultarReservasForm
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
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.DgvReservasClientes = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnConsultarReservas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvReservasClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Consultar Reservas Clientes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Location = new System.Drawing.Point(178, 116);
            this.TxtUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(250, 22);
            this.TxtUsuario.TabIndex = 2;
            // 
            // DgvReservasClientes
            // 
            this.DgvReservasClientes.AllowUserToAddRows = false;
            this.DgvReservasClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvReservasClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.DgvReservasClientes.Location = new System.Drawing.Point(55, 185);
            this.DgvReservasClientes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DgvReservasClientes.Name = "DgvReservasClientes";
            this.DgvReservasClientes.ReadOnly = true;
            this.DgvReservasClientes.RowHeadersWidth = 62;
            this.DgvReservasClientes.RowTemplate.Height = 28;
            this.DgvReservasClientes.Size = new System.Drawing.Size(365, 120);
            this.DgvReservasClientes.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Clase";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Fecha";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // BtnConsultarReservas
            // 
            this.BtnConsultarReservas.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnConsultarReservas.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConsultarReservas.Location = new System.Drawing.Point(231, 349);
            this.BtnConsultarReservas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnConsultarReservas.Name = "BtnConsultarReservas";
            this.BtnConsultarReservas.Size = new System.Drawing.Size(158, 46);
            this.BtnConsultarReservas.TabIndex = 4;
            this.BtnConsultarReservas.Text = "Consultar";
            this.BtnConsultarReservas.UseVisualStyleBackColor = false;
            this.BtnConsultarReservas.Click += new System.EventHandler(this.BtnConsultarReservas_Click);
            // 
            // ConsultarReservasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1012, 451);
            this.Controls.Add(this.BtnConsultarReservas);
            this.Controls.Add(this.DgvReservasClientes);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ConsultarReservasForm";
            this.Text = "ConsultarReservasForm";
            this.Load += new System.EventHandler(this.ConsultarReservasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvReservasClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.DataGridView DgvReservasClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button BtnConsultarReservas;
    }
}