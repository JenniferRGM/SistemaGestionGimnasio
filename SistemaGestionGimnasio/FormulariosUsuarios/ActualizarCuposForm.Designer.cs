namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    partial class ActualizarCuposForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.NumNuevoCupo = new System.Windows.Forms.NumericUpDown();
            this.BtnActualizarCupo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumNuevoCupo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(360, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Actualización de Cupos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 122);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "Clase:";
            // 
            // CmbClases
            // 
            this.CmbClases.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbClases.FormattingEnabled = true;
            this.CmbClases.Location = new System.Drawing.Point(166, 128);
            this.CmbClases.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CmbClases.Name = "CmbClases";
            this.CmbClases.Size = new System.Drawing.Size(256, 33);
            this.CmbClases.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 232);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 40);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cupo:";
            // 
            // NumNuevoCupo
            // 
            this.NumNuevoCupo.Location = new System.Drawing.Point(166, 239);
            this.NumNuevoCupo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NumNuevoCupo.Name = "NumNuevoCupo";
            this.NumNuevoCupo.Size = new System.Drawing.Size(180, 26);
            this.NumNuevoCupo.TabIndex = 4;
            // 
            // BtnActualizarCupo
            // 
            this.BtnActualizarCupo.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnActualizarCupo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizarCupo.Location = new System.Drawing.Point(323, 349);
            this.BtnActualizarCupo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnActualizarCupo.Name = "BtnActualizarCupo";
            this.BtnActualizarCupo.Size = new System.Drawing.Size(181, 88);
            this.BtnActualizarCupo.TabIndex = 5;
            this.BtnActualizarCupo.Text = "Actualizar";
            this.BtnActualizarCupo.UseVisualStyleBackColor = false;
            this.BtnActualizarCupo.Click += new System.EventHandler(this.BtnActualizarCupo_Click);
            // 
            // ActualizarCuposForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.BtnActualizarCupo);
            this.Controls.Add(this.NumNuevoCupo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbClases);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ActualizarCuposForm";
            this.Text = "ActualizarCuposForm";
            this.Load += new System.EventHandler(this.ActualizarCuposForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumNuevoCupo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbClases;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NumNuevoCupo;
        private System.Windows.Forms.Button BtnActualizarCupo;
    }
}