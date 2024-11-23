using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaGestionGimnasio.Modelos;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class NotificacionesMantenimientoForm : Form
    {
        public NotificacionesMantenimientoForm()
        {
            InitializeComponent();
        }

        private void NotificacionesMantenimientoForm_Load(object sender, EventArgs e)
        {
            CargarNotificaciones();

        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarNotificaciones();
        }

        private void CargarNotificaciones()
        {
            string rutaArchivo = "inventario.csv";

            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("El archivo de inventario no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Inventario> equiposPorMantener = new List<Inventario>();

            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    string[] datos = linea.Split(',');

                    if (datos.Length >= 5) 
                    {
                        string nombreEquipo = datos[0];
                        string categoria = datos[1];
                        DateTime fechaAdquisicion = DateTime.ParseExact(datos[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        int vidaUtil = int.Parse(datos[3]); 
                        string estado = datos[4];

                        // Calcular si se requiere mantenimiento
                        DateTime fechaFinalVida = fechaAdquisicion.AddMonths(vidaUtil);
                        if (DateTime.Now >= fechaFinalVida && estado == "Activo")
                        {
                            Inventario equipo = new Inventario
                            {
                                NombreEquipo = nombreEquipo,
                                Categoria = categoria,
                                FechaAdquisicion = fechaAdquisicion,
                                VidaUtilEstimada = datos[3],
                                Estado = estado
                            };

                            equiposPorMantener.Add(equipo);
                        }
                    }
                }
            }

            // Asignar la lista al DataGridView
            DgvMantenimiento.DataSource = equiposPorMantener;

            // Mostrar mensaje si no hay equipos por mantener
            if (equiposPorMantener.Count == 0)
            {
                MessageBox.Show("No hay equipos que necesiten mantenimiento en este momento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
