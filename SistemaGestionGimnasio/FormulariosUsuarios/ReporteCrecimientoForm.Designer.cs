namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    partial class ReporteCrecimientoForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.FechaFin = new System.Windows.Forms.DateTimePicker();
            this.BtnGenerarReporte = new System.Windows.Forms.Button();
            this.DgvReporte = new System.Windows.Forms.DataGridView();
            this.ChartCrecimiento = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.DgvReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartCrecimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(538, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reporte de Crecimiento de Membrecias";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Inicio:";
            // 
            // FechaInicio
            // 
            this.FechaInicio.Location = new System.Drawing.Point(185, 65);
            this.FechaInicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.Size = new System.Drawing.Size(282, 22);
            this.FechaInicio.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 32);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha Fin:";
            // 
            // FechaFin
            // 
            this.FechaFin.Location = new System.Drawing.Point(153, 106);
            this.FechaFin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.Size = new System.Drawing.Size(289, 22);
            this.FechaFin.TabIndex = 4;
            // 
            // BtnGenerarReporte
            // 
            this.BtnGenerarReporte.BackColor = System.Drawing.Color.LightBlue;
            this.BtnGenerarReporte.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGenerarReporte.Location = new System.Drawing.Point(191, 142);
            this.BtnGenerarReporte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnGenerarReporte.Name = "BtnGenerarReporte";
            this.BtnGenerarReporte.Size = new System.Drawing.Size(251, 35);
            this.BtnGenerarReporte.TabIndex = 5;
            this.BtnGenerarReporte.Text = "Generar Reporte";
            this.BtnGenerarReporte.UseVisualStyleBackColor = false;
            this.BtnGenerarReporte.Click += new System.EventHandler(this.BtnGenerarReporte_Click);
            // 
            // DgvReporte
            // 
            this.DgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvReporte.Location = new System.Drawing.Point(12, 241);
            this.DgvReporte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DgvReporte.Name = "DgvReporte";
            this.DgvReporte.ReadOnly = true;
            this.DgvReporte.RowHeadersWidth = 62;
            this.DgvReporte.RowTemplate.Height = 28;
            this.DgvReporte.Size = new System.Drawing.Size(486, 191);
            this.DgvReporte.TabIndex = 6;
            // 
            // ChartCrecimiento
            // 
            chartArea2.Name = "ChartArea1";
            this.ChartCrecimiento.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ChartCrecimiento.Legends.Add(legend2);
            this.ChartCrecimiento.Location = new System.Drawing.Point(606, 179);
            this.ChartCrecimiento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChartCrecimiento.Name = "ChartCrecimiento";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.ChartCrecimiento.Series.Add(series2);
            this.ChartCrecimiento.Size = new System.Drawing.Size(522, 301);
            this.ChartCrecimiento.TabIndex = 7;
            // 
            // ReporteCrecimientoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1174, 608);
            this.Controls.Add(this.ChartCrecimiento);
            this.Controls.Add(this.DgvReporte);
            this.Controls.Add(this.BtnGenerarReporte);
            this.Controls.Add(this.FechaFin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FechaInicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ReporteCrecimientoForm";
            this.Text = "ReporteCrecimientoForm";
            this.Load += new System.EventHandler(this.ReporteCrecimientoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartCrecimiento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker FechaInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker FechaFin;
        private System.Windows.Forms.Button BtnGenerarReporte;
        private System.Windows.Forms.DataGridView DgvReporte;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartCrecimiento;
    }
}