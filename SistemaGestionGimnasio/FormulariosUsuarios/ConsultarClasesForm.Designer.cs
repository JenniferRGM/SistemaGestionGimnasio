namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    partial class ConsultarClasesForm
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
            this.DgvClases = new System.Windows.Forms.DataGridView();
            this.NombreClase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaClase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuposDisponibles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClases)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvClases
            // 
            this.DgvClases.AllowUserToAddRows = false;
            this.DgvClases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvClases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvClases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreClase,
            this.FechaClase,
            this.CuposDisponibles});
            this.DgvClases.Location = new System.Drawing.Point(210, 130);
            this.DgvClases.Margin = new System.Windows.Forms.Padding(4);
            this.DgvClases.Name = "DgvClases";
            this.DgvClases.ReadOnly = true;
            this.DgvClases.RowHeadersWidth = 51;
            this.DgvClases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvClases.Size = new System.Drawing.Size(579, 197);
            this.DgvClases.TabIndex = 0;
            // 
            // NombreClase
            // 
            this.NombreClase.HeaderText = "Clase";
            this.NombreClase.MinimumWidth = 6;
            this.NombreClase.Name = "NombreClase";
            this.NombreClase.ReadOnly = true;
            // 
            // FechaClase
            // 
            this.FechaClase.HeaderText = "Fecha de la clase";
            this.FechaClase.MinimumWidth = 6;
            this.FechaClase.Name = "FechaClase";
            this.FechaClase.ReadOnly = true;
            // 
            // CuposDisponibles
            // 
            this.CuposDisponibles.HeaderText = "Cupos Disponibles";
            this.CuposDisponibles.MinimumWidth = 6;
            this.CuposDisponibles.Name = "CuposDisponibles";
            this.CuposDisponibles.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(407, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clases";
            // 
            // ConsultarClasesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgvClases);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConsultarClasesForm";
            this.Text = "ConsultarClasesForm";
            this.Load += new System.EventHandler(this.ConsultarClasesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvClases)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvClases;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreClase;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaClase;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuposDisponibles;
    }
}