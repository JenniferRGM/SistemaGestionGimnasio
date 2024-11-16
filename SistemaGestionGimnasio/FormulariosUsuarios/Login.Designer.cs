namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    partial class Login
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CbxMostrarClave = new System.Windows.Forms.CheckBox();
            this.txtClave = new SistemaGestionGimnasio.CustomTextBox();
            this.txtUsuario = new SistemaGestionGimnasio.CustomTextBox();
            this.BtnIniciarSesion = new SistemaGestionGimnasio.RoundedButton();
            this.customTextBox2 = new SistemaGestionGimnasio.CustomTextBox();
            this.customTextBox1 = new SistemaGestionGimnasio.CustomTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::SistemaGestionGimnasio.Properties.Resources.Icono;
            this.pictureBox2.Image = global::SistemaGestionGimnasio.Properties.Resources.Icono;
            this.pictureBox2.Location = new System.Drawing.Point(111, 52);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(119, 104);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::SistemaGestionGimnasio.Properties.Resources.Login;
            this.pictureBox1.Image = global::SistemaGestionGimnasio.Properties.Resources.Login;
            this.pictureBox1.Location = new System.Drawing.Point(378, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(422, 452);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "Contraseña";
            // 
            // CbxMostrarClave
            // 
            this.CbxMostrarClave.AutoSize = true;
            this.CbxMostrarClave.BackColor = System.Drawing.Color.Transparent;
            this.CbxMostrarClave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CbxMostrarClave.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbxMostrarClave.ForeColor = System.Drawing.Color.White;
            this.CbxMostrarClave.Location = new System.Drawing.Point(18, 332);
            this.CbxMostrarClave.Name = "CbxMostrarClave";
            this.CbxMostrarClave.Size = new System.Drawing.Size(113, 21);
            this.CbxMostrarClave.TabIndex = 11;
            this.CbxMostrarClave.Text = "Mostrar clave";
            this.CbxMostrarClave.UseVisualStyleBackColor = false;
            this.CbxMostrarClave.CheckedChanged += new System.EventHandler(this.CbxMostrarClave_CheckedChanged);
            // 
            // txtClave
            // 
            this.txtClave.BackColor = System.Drawing.Color.MidnightBlue;
            this.txtClave.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtClave.BorderRadius = 8;
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClave.BorderThickness = 1;
            this.txtClave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.ForeColor = System.Drawing.Color.Aqua;
            this.txtClave.Location = new System.Drawing.Point(19, 285);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(211, 27);
            this.txtClave.TabIndex = 10;
            this.txtClave.UseSystemPasswordChar = true;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.MidnightBlue;
            this.txtUsuario.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtUsuario.BorderRadius = 8;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.BorderThickness = 1;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.Aqua;
            this.txtUsuario.Location = new System.Drawing.Point(19, 211);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(211, 27);
            this.txtUsuario.TabIndex = 9;
            // 
            // BtnIniciarSesion
            // 
            this.BtnIniciarSesion.BorderColor = System.Drawing.Color.DodgerBlue;
            this.BtnIniciarSesion.BorderRadius = 8;
            this.BtnIniciarSesion.BorderThickness = 1;
            this.BtnIniciarSesion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIniciarSesion.Location = new System.Drawing.Point(88, 368);
            this.BtnIniciarSesion.Name = "BtnIniciarSesion";
            this.BtnIniciarSesion.Size = new System.Drawing.Size(164, 39);
            this.BtnIniciarSesion.TabIndex = 8;
            this.BtnIniciarSesion.Text = "Iniciar Sesión";
            this.BtnIniciarSesion.UseVisualStyleBackColor = true;
            this.BtnIniciarSesion.Click += new System.EventHandler(this.BtnIniciarSesion_Click);
            // 
            // customTextBox2
            // 
            this.customTextBox2.BackColor = System.Drawing.Color.DarkBlue;
            this.customTextBox2.BorderColor = System.Drawing.Color.DodgerBlue;
            this.customTextBox2.BorderRadius = 8;
            this.customTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.customTextBox2.BorderThickness = 1;
            this.customTextBox2.Location = new System.Drawing.Point(18, 303);
            this.customTextBox2.Name = "customTextBox2";
            this.customTextBox2.Size = new System.Drawing.Size(179, 15);
            this.customTextBox2.TabIndex = 6;
            this.customTextBox2.UseSystemPasswordChar = true;
            // 
            // customTextBox1
            // 
            this.customTextBox1.BackColor = System.Drawing.Color.DarkBlue;
            this.customTextBox1.BorderColor = System.Drawing.Color.DodgerBlue;
            this.customTextBox1.BorderRadius = 8;
            this.customTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.customTextBox1.BorderThickness = 1;
            this.customTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.customTextBox1.ForeColor = System.Drawing.Color.Aqua;
            this.customTextBox1.Location = new System.Drawing.Point(18, 211);
            this.customTextBox1.Name = "customTextBox1";
            this.customTextBox1.Size = new System.Drawing.Size(179, 15);
            this.customTextBox1.TabIndex = 5;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CbxMostrarClave);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.BtnIniciarSesion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.customTextBox2);
            this.Controls.Add(this.customTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Login";
            this.Opacity = 0.8D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private CustomTextBox customTextBox1;
        private CustomTextBox customTextBox2;
        private System.Windows.Forms.Label label2;
        private RoundedButton BtnIniciarSesion;
        private CustomTextBox txtUsuario;
        private CustomTextBox txtClave;
        private System.Windows.Forms.CheckBox CbxMostrarClave;
    }
}