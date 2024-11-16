using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace SistemaGestionGimnasio.Modelos
{
    internal class Membresia
    {
        public string Usuario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public Membresia(DateTime fechaInicio, DateTime fechaVencimiento)
        {
            FechaInicio = fechaInicio;
            FechaVencimiento = fechaVencimiento;
        }

        public int DiasRestantes()
        {
            return (FechaVencimiento - DateTime.Now).Days;
        }

        public bool EstaPorVencer()
        {
            return DiasRestantes() <= 5;
        }

        public static Membresia ObtenerMembresia(string usuario)
        {
            string rutaArchivo = "membresias.csv";

            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("Archivo de membresías no encontrado.");
                return null;

            }

            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                string linea;
                string formatoFecha = "dd/MM/yyyy";

                while ((linea = lector.ReadLine()) != null)
                {
                    string[] datos = linea.Split(',');

                    if (datos.Length >= 3 && datos[0].Trim().Equals(usuario.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        if (!DateTime.TryParseExact(datos[1], formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaInicio) ||
                            !DateTime.TryParseExact(datos[2], formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaVencimiento))
                        {
                            MessageBox.Show($"Error al procesar las fechas para el usuario: {usuario}");
                            return null;
                        }

                        return new Membresia(fechaInicio, fechaVencimiento);
                    }
                }
            }


            MessageBox.Show($"No se encontró membresía asociada al usuario.");
            return null;
        }
    }
}
                    
                
            

            
        






