using SistemaGestionGimnasio.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class ConsultarInventarioForm : Form
    {
        public ConsultarInventarioForm()
        {
            InitializeComponent();
        }

        private void ConsultarInventarioForm_Load(object sender, EventArgs e)
        {
            CargarInventario();
        }

        private void CargarInventario()
        {
            string rutaArchivo = "inventario.csv";
            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("El archivo de inventario no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Leer datos desde el archivo
            List<Inventario> listaInventario = new List<Inventario>();

            try
            {
                using (StreamReader lector = new StreamReader(rutaArchivo))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {
                        string[] datos = linea.Split(',');

                        if (datos.Length >= 5)
                        {
                            Inventario item = new Inventario
                            {
                                NombreEquipo = datos[0],
                                Categoria = datos[1],
                                FechaAdquisicion = DateTime.ParseExact(datos[2], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None),
                                VidaUtilEstimada = datos[3],
                                Estado = datos[4]
                            };

                            listaInventario.Add(item);
                        }
                    }
                }

                // Asignar la lista al DataGridView
                DgvInventario.DataSource = listaInventario;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el inventario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarInventario();
        }
    }
}
