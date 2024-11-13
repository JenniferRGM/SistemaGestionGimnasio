namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    partial class AsignarHorariosPuntosFuertesForm
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
            this.CmbEntrenador = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxHorariosDisponibles = new System.Windows.Forms.ListBox();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BntCancelar = new System.Windows.Forms.Button();
            this.listBoxPuntosFuertes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccionar Entrenador:";
            // 
            // CmbEntrenador
            // 
            this.CmbEntrenador.FormattingEnabled = true;
            this.CmbEntrenador.Location = new System.Drawing.Point(258, 52);
            this.CmbEntrenador.Name = "CmbEntrenador";
            this.CmbEntrenador.Size = new System.Drawing.Size(244, 21);
            this.CmbEntrenador.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Horarios Disponibles:";
            // 
            // listBoxHorariosDisponibles
            // 
            this.listBoxHorariosDisponibles.FormattingEnabled = true;
            this.listBoxHorariosDisponibles.Location = new System.Drawing.Point(61, 111);
            this.listBoxHorariosDisponibles.Name = "listBoxHorariosDisponibles";
            this.listBoxHorariosDisponibles.Size = new System.Drawing.Size(120, 95);
            this.listBoxHorariosDisponibles.TabIndex = 3;
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.BackColor = System.Drawing.Color.OliveDrab;
            this.BtnAgregar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Location = new System.Drawing.Point(69, 212);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(99, 50);
            this.BtnAgregar.TabIndex = 4;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = false;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Puntos Fuertes:";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.BackColor = System.Drawing.Color.OliveDrab;
            this.BtnGuardar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.Location = new System.Drawing.Point(258, 343);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(117, 43);
            this.BtnGuardar.TabIndex = 7;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BntCancelar
            // 
            this.BntCancelar.BackColor = System.Drawing.Color.OliveDrab;
            this.BntCancelar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BntCancelar.Location = new System.Drawing.Point(421, 343);
            this.BntCancelar.Name = "BntCancelar";
            this.BntCancelar.Size = new System.Drawing.Size(119, 43);
            this.BntCancelar.TabIndex = 8;
            this.BntCancelar.Text = "Cancelar";
            this.BntCancelar.UseVisualStyleBackColor = false;
            this.BntCancelar.Click += new System.EventHandler(this.BntCancelar_Click);
            // 
            // listBoxPuntosFuertes
            // 
            this.listBoxPuntosFuertes.FormattingEnabled = true;
            this.listBoxPuntosFuertes.Location = new System.Drawing.Point(61, 312);
            this.listBoxPuntosFuertes.Name = "listBoxPuntosFuertes";
            this.listBoxPuntosFuertes.Size = new System.Drawing.Size(120, 95);
            this.listBoxPuntosFuertes.TabIndex = 9;
            this.listBoxPuntosFuertes.SelectedIndexChanged += new System.EventHandler(this.listBoxPuntosFuertes_SelectedIndexChanged);
            // 
            // AsignarHorariosPuntosFuertesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxPuntosFuertes);
            this.Controls.Add(this.BntCancelar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.listBoxHorariosDisponibles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbEntrenador);
            this.Controls.Add(this.label1);
            this.Name = "AsignarHorariosPuntosFuertesForm";
            this.Text = "AsignarHorariosPuntosFuertesForm";
            this.Load += new System.EventHandler(this.AsignarHorariosPuntosFuertesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbEntrenador;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxHorariosDisponibles;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BntCancelar;
        private System.Windows.Forms.ListBox listBoxPuntosFuertes;
    }
}