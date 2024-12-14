namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    partial class InformeContableForm
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
            this.DtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.DtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.BtnGenerarInforme = new System.Windows.Forms.Button();
            this.LblTotalIngresos = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblTotalGastos = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LblBalance = new System.Windows.Forms.Label();
            this.DgvInformeContable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvInformeContable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(376, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Informe Contable";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Inicio:";
            // 
            // DtpFechaInicio
            // 
            this.DtpFechaInicio.Location = new System.Drawing.Point(202, 89);
            this.DtpFechaInicio.Name = "DtpFechaInicio";
            this.DtpFechaInicio.Size = new System.Drawing.Size(271, 22);
            this.DtpFechaInicio.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(559, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 31);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha Fin:";
            // 
            // DtpFechaFin
            // 
            this.DtpFechaFin.Location = new System.Drawing.Point(715, 89);
            this.DtpFechaFin.Name = "DtpFechaFin";
            this.DtpFechaFin.Size = new System.Drawing.Size(268, 22);
            this.DtpFechaFin.TabIndex = 4;
            // 
            // BtnGenerarInforme
            // 
            this.BtnGenerarInforme.BackColor = System.Drawing.Color.PaleTurquoise;
            this.BtnGenerarInforme.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGenerarInforme.Location = new System.Drawing.Point(437, 137);
            this.BtnGenerarInforme.Name = "BtnGenerarInforme";
            this.BtnGenerarInforme.Size = new System.Drawing.Size(129, 47);
            this.BtnGenerarInforme.TabIndex = 5;
            this.BtnGenerarInforme.Text = "Informe";
            this.BtnGenerarInforme.UseVisualStyleBackColor = false;
            this.BtnGenerarInforme.Click += new System.EventHandler(this.BtnGenerarInforme_Click);
            // 
            // LblTotalIngresos
            // 
            this.LblTotalIngresos.AutoSize = true;
            this.LblTotalIngresos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalIngresos.Location = new System.Drawing.Point(211, 237);
            this.LblTotalIngresos.Name = "LblTotalIngresos";
            this.LblTotalIngresos.Size = new System.Drawing.Size(56, 28);
            this.LblTotalIngresos.TabIndex = 6;
            this.LblTotalIngresos.Text = "\"    \"";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(33, 234);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(159, 31);
            this.label.TabIndex = 7;
            this.label.Text = "Total Ingreso:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(364, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 31);
            this.label6.TabIndex = 8;
            this.label6.Text = "Total Gastos:";
            // 
            // LblTotalGastos
            // 
            this.LblTotalGastos.AutoSize = true;
            this.LblTotalGastos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalGastos.Location = new System.Drawing.Point(535, 237);
            this.LblTotalGastos.Name = "LblTotalGastos";
            this.LblTotalGastos.Size = new System.Drawing.Size(50, 28);
            this.LblTotalGastos.TabIndex = 9;
            this.LblTotalGastos.Text = "\"   \"";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(736, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 31);
            this.label8.TabIndex = 10;
            this.label8.Text = "Balance:";
            // 
            // LblBalance
            // 
            this.LblBalance.AutoSize = true;
            this.LblBalance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBalance.Location = new System.Drawing.Point(869, 238);
            this.LblBalance.Name = "LblBalance";
            this.LblBalance.Size = new System.Drawing.Size(50, 28);
            this.LblBalance.TabIndex = 11;
            this.LblBalance.Text = "\"   \"";
            // 
            // DgvInformeContable
            // 
            this.DgvInformeContable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvInformeContable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvInformeContable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.DgvInformeContable.Location = new System.Drawing.Point(39, 287);
            this.DgvInformeContable.Name = "DgvInformeContable";
            this.DgvInformeContable.ReadOnly = true;
            this.DgvInformeContable.RowHeadersWidth = 51;
            this.DgvInformeContable.RowTemplate.Height = 24;
            this.DgvInformeContable.Size = new System.Drawing.Size(1053, 279);
            this.DgvInformeContable.TabIndex = 12;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Fecha";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Descripción";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Ingreso";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Gasto";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // InformeContableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1144, 597);
            this.Controls.Add(this.DgvInformeContable);
            this.Controls.Add(this.LblBalance);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.LblTotalGastos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label);
            this.Controls.Add(this.LblTotalIngresos);
            this.Controls.Add(this.BtnGenerarInforme);
            this.Controls.Add(this.DtpFechaFin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DtpFechaInicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InformeContableForm";
            this.Text = "InformeContableForm";
            this.Load += new System.EventHandler(this.InformeContableForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvInformeContable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpFechaInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DtpFechaFin;
        private System.Windows.Forms.Button BtnGenerarInforme;
        private System.Windows.Forms.Label LblTotalIngresos;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblTotalGastos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LblBalance;
        private System.Windows.Forms.DataGridView DgvInformeContable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}