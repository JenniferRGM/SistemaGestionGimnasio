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
using SistemaGestionGimnasio.DataHandler;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class NotificacionesMantenimientoForm : Form
    {
        private IDataHandler dataHandler;
        public NotificacionesMantenimientoForm(IDataHandler handler)
        {
            InitializeComponent();
            this.dataHandler = handler;
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

            if (!dataHandler.FileExists(rutaArchivo))
            {
                MessageBox.Show("El archivo de inventario no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Inventario> equiposPorMantener = new List<Inventario>();

            try
            {
                var lineas = dataHandler.ReadAllLines(rutaArchivo);

                foreach (var linea in lineas)
                {
                    if (string.IsNullOrWhiteSpace(linea)) continue;

                    string[] datos = linea.Split(',');

                    if (datos.Length < 5)
                    {
                        MessageBox.Show($"Línea incompleta ignorada: {linea}", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    string nombreEquipo = datos[0];
                    string categoria = datos[1];
                    if (!DateTime.TryParseExact(datos[2], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaAdquisicion))
                    {
                        MessageBox.Show($"Fecha de adquisición inválida para el equipo '{nombreEquipo}'.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    if (!int.TryParse(datos[3], out int vidaUtil))
                    {
                        MessageBox.Show($"Vida útil inválida para el equipo '{nombreEquipo}'.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    string estado = datos[4];

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

                // Asignar los datos al DataGridView
                DgvMantenimiento.DataSource = null;
                DgvMantenimiento.DataSource = equiposPorMantener;

                if (equiposPorMantener.Count == 0)
                {
                    MessageBox.Show("No hay equipos que necesiten mantenimiento en este momento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar las notificaciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
