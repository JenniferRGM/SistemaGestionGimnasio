﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaGestionGimnasio.DataHandler;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class ConsultarUsuarioForm : Form
    {
        private readonly IDataHandler dataHandler;
        public ConsultarUsuarioForm(IDataHandler dataHandler)
        {
            InitializeComponent();
            this.dataHandler = dataHandler;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string idBuscado = txtBuscarID.Text;

            // Llama al método para buscar el usuario en el archivo CSV
            bool encontrado = BuscarUsuarioEnCsv(idBuscado);

            if (!encontrado)
            {
                MessageBox.Show("Usuario no encontrado");
            }
        }

        private bool BuscarUsuarioEnCsv(string idBuscado)
        {
            string rutaArchivo = "usuarios.csv";

            // Verificar si el archivo CSV existe
            if (!dataHandler.FileExists(rutaArchivo))
            {
                MessageBox.Show("El archivo de usuarios no existe.");
                return false;
            }

            // Leer el archivo CSV y buscar el usuario
            var lineas = dataHandler.ReadAllLines(rutaArchivo);
            foreach (var linea in lineas)
            {
                string[] datos = linea.Split(',');

                // Verificar si el primer campo (ID) coincide con el ID buscado
                if (datos[0] == idBuscado)
                {
                    // Mostrar los datos en los campos de solo lectura
                    txtID.Text = datos[0];
                    txtNombre.Text = datos[1];
                    txtCorreo.Text = datos[2];
                    txtTipo.Text = datos[3];
                    return true; 
                }
            }

            return false; 
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConsultarUsuarioForm_Load(object sender, EventArgs e)
        {
            // Configurar los campos como solo lectura
            txtID.ReadOnly = true;
            txtNombre.ReadOnly = true;
            txtCorreo.ReadOnly = true;
            txtTipo.ReadOnly = true;

            // Configurar el placeholder para el campo de búsqueda
            txtBuscarID.ForeColor = Color.Gray;
            txtBuscarID.Text = "Digite el ID del usuario";

            // Agregar eventos para simular el placeholder
            txtBuscarID.Enter += new EventHandler(RemoverPlaceholder);
            txtBuscarID.Leave += new EventHandler(AgregarPlaceholder);
        }

        private void RemoverPlaceholder(object sender, EventArgs e)
        {
            if (txtBuscarID.Text == "Digite el ID del usuario")
            {
                txtBuscarID.Text = "";
                txtBuscarID.ForeColor = Color.Black;
            }
        }

        private void AgregarPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscarID.Text))
            {
                txtBuscarID.Text = "Digite el ID del usuario";
                txtBuscarID.ForeColor = Color.Gray;
            }
        }

    }

}

