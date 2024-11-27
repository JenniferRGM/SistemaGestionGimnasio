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
            string rutaArchivo = Path.Combine("Assets", "membresias.csv");

            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show($"El archivo {rutaArchivo} no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                string linea;
                bool esPrimeraLinea = true;

                while ((linea = lector.ReadLine()) != null)
                {
                    if (esPrimeraLinea)
                    {
                        esPrimeraLinea = false;
                        continue;
                    }

                    string[] datos = linea.Split(',');
                    if (datos.Length >= 3 && datos[0] == usuario)
                    {
                        if (DateTime.TryParseExact(datos[1].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaInicio) &&
                   DateTime.TryParseExact(datos[2].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaVencimiento))
                        {
                            return new Membresia(fechaInicio, fechaVencimiento);
                        }
                        else
                        {
                            MessageBox.Show($"Error en el formato de las fechas para el usuario {usuario}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
                    }
                }
            }

            return null; 
        }
    }
}











