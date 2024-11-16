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
                while ((linea = lector.ReadLine()) != null)
                {
                    string[] datos = linea.Split(',');

                    if (datos.Length >= 3 && datos[0] == usuario)
                    {
                        string formatoFecha = "dd/MM/yyyy";
                        DateTime fechaInicio = DateTime.ParseExact(datos[1], formatoFecha, CultureInfo.InvariantCulture);
                        DateTime fechaVencimiento = DateTime.ParseExact(datos[2], formatoFecha, CultureInfo.InvariantCulture);
                        return new Membresia(fechaInicio, fechaVencimiento);
                    }
                    
                }
            }

            
            return null;
        }
    }
}
