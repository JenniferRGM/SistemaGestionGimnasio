namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    partial class GestionFacturasForm
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
            this.TxtCliente = new System.Windows.Forms.TextBox();
            this.TxtMonto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbEstado = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.DgvFacturas = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.BtnEmitirFacturasMensuales = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(293, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestión de Facturas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cliente:";
            // 
            // TxtCliente
            // 
            this.TxtCliente.Location = new System.Drawing.Point(105, 99);
            this.TxtCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtCliente.Name = "TxtCliente";
            this.TxtCliente.Size = new System.Drawing.Size(202, 22);
            this.TxtCliente.TabIndex = 2;
            // 
            // TxtMonto
            // 
            this.TxtMonto.Location = new System.Drawing.Point(422, 101);
            this.TxtMonto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtMonto.Name = "TxtMonto";
            this.TxtMonto.Size = new System.Drawing.Size(205, 22);
            this.TxtMonto.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(336, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Monto:";
            // 
            // CmbEstado
            // 
            this.CmbEstado.FormattingEnabled = true;
            this.CmbEstado.Location = new System.Drawing.Point(105, 143);
            this.CmbEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CmbEstado.Name = "CmbEstado";
            this.CmbEstado.Size = new System.Drawing.Size(193, 24);
            this.CmbEstado.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "Estado:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(223, 28);
            this.label5.TabIndex = 7;
            this.label5.Text = "Generación de Factura";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(324, 170);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 34);
            this.button1.TabIndex = 8;
            this.button1.Text = "Generar Factura";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.BtnGenerarFactura);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(210, 28);
            this.label6.TabIndex = 9;
            this.label6.Text = "Sección de Consultas";
            // 
            // DgvFacturas
            // 
            this.DgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.DgvFacturas.Location = new System.Drawing.Point(16, 259);
            this.DgvFacturas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DgvFacturas.Name = "DgvFacturas";
            this.DgvFacturas.ReadOnly = true;
            this.DgvFacturas.RowHeadersWidth = 62;
            this.DgvFacturas.RowTemplate.Height = 28;
            this.DgvFacturas.Size = new System.Drawing.Size(671, 120);
            this.DgvFacturas.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(130, 410);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 34);
            this.button2.TabIndex = 11;
            this.button2.Text = "Actualizar";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // BtnEmitirFacturasMensuales
            // 
            this.BtnEmitirFacturasMensuales.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnEmitirFacturasMensuales.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEmitirFacturasMensuales.Location = new System.Drawing.Point(384, 410);
            this.BtnEmitirFacturasMensuales.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnEmitirFacturasMensuales.Name = "BtnEmitirFacturasMensuales";
            this.BtnEmitirFacturasMensuales.Size = new System.Drawing.Size(169, 34);
            this.BtnEmitirFacturasMensuales.TabIndex = 12;
            this.BtnEmitirFacturasMensuales.Text = "Emitir Factura";
            this.BtnEmitirFacturasMensuales.UseVisualStyleBackColor = false;
            this.BtnEmitirFacturasMensuales.Click += new System.EventHandler(this.BtnEmitirFacturasMensuales_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Num.Factura";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Fecha Emision";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Cliente";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Monto";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Estado";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 125;
            // 
            // GestionFacturasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(952, 483);
            this.Controls.Add(this.BtnEmitirFacturasMensuales);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.DgvFacturas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CmbEstado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtMonto);
            this.Controls.Add(this.TxtCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GestionFacturasForm";
            this.Text = "GestionFacturasForm";
            ((System.ComponentModel.ISupportInitialize)(this.DgvFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtCliente;
        private System.Windows.Forms.TextBox TxtMonto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbEstado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView DgvFacturas;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtnEmitirFacturasMensuales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}