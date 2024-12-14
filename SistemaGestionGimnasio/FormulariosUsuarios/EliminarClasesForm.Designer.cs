namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    partial class EliminarClasesForm
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
            this.CmbClases = new System.Windows.Forms.ComboBox();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.DgvClasesMatriculadas = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClasesMatriculadas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(189, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Menú para Eliminar Clases";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Clase Matriculada:";
            // 
            // CmbClases
            // 
            this.CmbClases.FormattingEnabled = true;
            this.CmbClases.Location = new System.Drawing.Point(282, 114);
            this.CmbClases.Name = "CmbClases";
            this.CmbClases.Size = new System.Drawing.Size(207, 24);
            this.CmbClases.TabIndex = 2;
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.BackColor = System.Drawing.Color.SkyBlue;
            this.BtnEliminar.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.Location = new System.Drawing.Point(186, 165);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(124, 41);
            this.BtnEliminar.TabIndex = 3;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = false;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "Clases Matriculadas:";
            // 
            // DgvClasesMatriculadas
            // 
            this.DgvClasesMatriculadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvClasesMatriculadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.DgvClasesMatriculadas.Location = new System.Drawing.Point(38, 282);
            this.DgvClasesMatriculadas.Name = "DgvClasesMatriculadas";
            this.DgvClasesMatriculadas.RowHeadersWidth = 51;
            this.DgvClasesMatriculadas.RowTemplate.Height = 24;
            this.DgvClasesMatriculadas.Size = new System.Drawing.Size(422, 150);
            this.DgvClasesMatriculadas.TabIndex = 5;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Usuario";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Actividad";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // EliminarClasesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(935, 486);
            this.Controls.Add(this.DgvClasesMatriculadas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.CmbClases);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EliminarClasesForm";
            this.Text = "EliminarClasesForm";
            this.Load += new System.EventHandler(this.EliminarClasesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvClasesMatriculadas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbClases;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DgvClasesMatriculadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}