namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    partial class CrecimientoMatriculaForm
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.BtnGenerarReporte = new System.Windows.Forms.Button();
            this.DgvCrecimiento = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCrecimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(336, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reporte de Matrícula";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Inicio:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(184, 95);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(249, 22);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(464, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 31);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha Fin:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(604, 95);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(278, 22);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // BtnGenerarReporte
            // 
            this.BtnGenerarReporte.BackColor = System.Drawing.Color.MediumTurquoise;
            this.BtnGenerarReporte.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGenerarReporte.Location = new System.Drawing.Point(421, 147);
            this.BtnGenerarReporte.Name = "BtnGenerarReporte";
            this.BtnGenerarReporte.Size = new System.Drawing.Size(132, 50);
            this.BtnGenerarReporte.TabIndex = 5;
            this.BtnGenerarReporte.Text = "Reporte";
            this.BtnGenerarReporte.UseVisualStyleBackColor = false;
            this.BtnGenerarReporte.Click += new System.EventHandler(this.BtnGenerarReporte_Click);
            // 
            // DgvCrecimiento
            // 
            this.DgvCrecimiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvCrecimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCrecimiento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.DgvCrecimiento.Location = new System.Drawing.Point(30, 218);
            this.DgvCrecimiento.Name = "DgvCrecimiento";
            this.DgvCrecimiento.ReadOnly = true;
            this.DgvCrecimiento.RowHeadersWidth = 51;
            this.DgvCrecimiento.RowTemplate.Height = 24;
            this.DgvCrecimiento.Size = new System.Drawing.Size(1033, 316);
            this.DgvCrecimiento.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Fecha Registro";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Membresias Nuevas";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Total de Membresias";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // CrecimientoMatriculaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1108, 546);
            this.Controls.Add(this.DgvCrecimiento);
            this.Controls.Add(this.BtnGenerarReporte);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CrecimientoMatriculaForm";
            this.Text = "ReporteDeMatriculaForm";
            ((System.ComponentModel.ISupportInitialize)(this.DgvCrecimiento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button BtnGenerarReporte;
        private System.Windows.Forms.DataGridView DgvCrecimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}