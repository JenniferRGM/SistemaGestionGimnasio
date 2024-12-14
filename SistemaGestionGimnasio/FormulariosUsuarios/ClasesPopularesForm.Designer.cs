namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    partial class ClasesPopularesForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbCategoria = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.DtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.BtnGenerarReporte = new System.Windows.Forms.Button();
            this.DgvClases = new System.Windows.Forms.DataGridView();
            this.ChartClases = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartClases)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(402, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clases Más Atractivas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(364, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccione la categoría de clases:";
            // 
            // CmbCategoria
            // 
            this.CmbCategoria.FormattingEnabled = true;
            this.CmbCategoria.Location = new System.Drawing.Point(393, 116);
            this.CmbCategoria.Name = "CmbCategoria";
            this.CmbCategoria.Size = new System.Drawing.Size(236, 24);
            this.CmbCategoria.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(70, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 31);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha Inicio:";
            // 
            // DtpFechaInicio
            // 
            this.DtpFechaInicio.Location = new System.Drawing.Point(234, 164);
            this.DtpFechaInicio.Name = "DtpFechaInicio";
            this.DtpFechaInicio.Size = new System.Drawing.Size(276, 22);
            this.DtpFechaInicio.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(600, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 31);
            this.label4.TabIndex = 5;
            this.label4.Text = "Fecha Fin:";
            // 
            // DtpFechaFin
            // 
            this.DtpFechaFin.Location = new System.Drawing.Point(747, 163);
            this.DtpFechaFin.Name = "DtpFechaFin";
            this.DtpFechaFin.Size = new System.Drawing.Size(271, 22);
            this.DtpFechaFin.TabIndex = 6;
            // 
            // BtnGenerarReporte
            // 
            this.BtnGenerarReporte.BackColor = System.Drawing.Color.SkyBlue;
            this.BtnGenerarReporte.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGenerarReporte.Location = new System.Drawing.Point(473, 223);
            this.BtnGenerarReporte.Name = "BtnGenerarReporte";
            this.BtnGenerarReporte.Size = new System.Drawing.Size(156, 50);
            this.BtnGenerarReporte.TabIndex = 7;
            this.BtnGenerarReporte.Text = "Generar";
            this.BtnGenerarReporte.UseVisualStyleBackColor = false;
            this.BtnGenerarReporte.Click += new System.EventHandler(this.BtnGenerarReporte_Click);
            // 
            // DgvClases
            // 
            this.DgvClases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvClases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.DgvClases.Location = new System.Drawing.Point(18, 311);
            this.DgvClases.Name = "DgvClases";
            this.DgvClases.RowHeadersWidth = 51;
            this.DgvClases.RowTemplate.Height = 24;
            this.DgvClases.Size = new System.Drawing.Size(524, 283);
            this.DgvClases.TabIndex = 8;
            // 
            // ChartClases
            // 
            chartArea1.Name = "ChartArea1";
            this.ChartClases.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartClases.Legends.Add(legend1);
            this.ChartClases.Location = new System.Drawing.Point(606, 311);
            this.ChartClases.Name = "ChartClases";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.ChartClases.Series.Add(series1);
            this.ChartClases.Size = new System.Drawing.Size(518, 283);
            this.ChartClases.TabIndex = 9;
            this.ChartClases.Text = "chart1";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nombre";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Asistentes";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Horario";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Fecha";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // ClasesPopularesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1163, 640);
            this.Controls.Add(this.ChartClases);
            this.Controls.Add(this.DgvClases);
            this.Controls.Add(this.BtnGenerarReporte);
            this.Controls.Add(this.DtpFechaFin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DtpFechaInicio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbCategoria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ClasesPopularesForm";
            this.Text = "ClasesPopularesForm";
            ((System.ComponentModel.ISupportInitialize)(this.DgvClases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartClases)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbCategoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DtpFechaInicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DtpFechaFin;
        private System.Windows.Forms.Button BtnGenerarReporte;
        private System.Windows.Forms.DataGridView DgvClases;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartClases;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}