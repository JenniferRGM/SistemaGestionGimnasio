using SistemaGestionGimnasio.Modelos;
using SistemaGestionGimnasio.DataHandler;
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
        private readonly IDataHandler dataHandler;
        public ConsultarInventarioForm(IDataHandler dataHandler)
        {
            InitializeComponent();
            this.dataHandler = dataHandler;
        }

        private void ConsultarInventarioForm_Load(object sender, EventArgs e)
        {
            CargarInventario();
        }

        private void CargarInventario()
        {
            string rutaArchivo = "Assets/inventario.csv"; // Ruta relativa al archivo

            if (!dataHandler.FileExists(rutaArchivo))
            {
                MessageBox.Show("El archivo de inventario no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lee datos desde el archivo
            List<Inventario> listaInventario = new List<Inventario>();

            try
            {
                var lineas = dataHandler.ReadAllLines(rutaArchivo).Skip(1); // Usa DataHandler para leer líneas
                foreach (var linea in lineas)
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
