using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestionGimnasio.Modelos
{
    public class Clases
    {
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public int Cupo { get; set; }
        public int CupoTotal { get; set; }
        public int CuposDisponibles { get; set; }

        public Clases(string nombre, DateTime fecha, int cupo)
        {
            Nombre = nombre;
            Fecha = fecha;
            Cupo = cupo;


        }

        public static List<Clases> CargarClasesDesdeArchivo(string rutaArchivo)
        {
            List<Clases> clasesDisponibles = new List<Clases>();

            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("El archivo de clases no existe.");
                return clasesDisponibles;
            }

            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                string linea;
                

                while ((linea = lector.ReadLine()) != null)
                {
                    string[] datos = linea.Split(',');
                    if (datos.Length >= 3)
                    {
                        try
                        {
                            string nombre = datos[0].Trim();
                            DateTime fecha = DateTime.ParseExact(datos[1].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            int cupo = int.Parse(datos[2].Trim());

                            clasesDisponibles.Add(new Clases(nombre, fecha, cupo));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al procesar la línea: {linea}\n{ex.Message}");
                        }
                    }
                }
            }

            return clasesDisponibles;
        }

        public static int ObtenerCupoActual(string rutaArchivo, string nombreClase, DateTime fecha)
        {
            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("El archivo de clases no se encontró.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            int cupoActual = 0;

            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    string[] datos = linea.Split(',');

                    if (datos.Length >= 3 &&
                        datos[0].Trim() == nombreClase &&
                        DateTime.TryParseExact(datos[1].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaArchivo) &&
                        fechaArchivo == fecha)
                    {
                        if (int.TryParse(datos[2], out int reservas))
                        {
                            cupoActual = reservas;
                        }
                        break;
                    }
                }
            }

            return cupoActual;
        }

        public static void ReservarClase(string rutaArchivo, string nombreClase, DateTime fecha)
        {
            List<string> lineas = new List<string>();

            if (File.Exists(rutaArchivo))
            {
                lineas = File.ReadAllLines(rutaArchivo).ToList();
            }

            bool claseEncontrada = false;
            string fechaFormato = fecha.ToString("dd/MM/yyyy");

            for (int i = 0; i < lineas.Count; i++)
            {
                string[] datos = lineas[i].Split(',');

                if (datos.Length >= 3 && datos[0].Trim() == nombreClase && datos[1].Trim() == fechaFormato && int.TryParse(datos[2], out int cupoActual))
                {
                    datos[2] = (cupoActual + 1).ToString();
                    lineas[i] = string.Join(",", datos);
                    claseEncontrada = true;
                    break;
                }
            }

            if (!claseEncontrada)
            {
                lineas.Add($"{nombreClase},{fechaFormato},1");
            }

            File.WriteAllLines(rutaArchivo, lineas);
        }

        public static void ActualizarArchivoClases(string rutaArchivo, List<Clases> clases)
        {
            using (StreamWriter escritor = new StreamWriter(rutaArchivo, false))
            {
                foreach (var clase in clases)
                {
                    escritor.WriteLine($"{clase.Nombre},{clase.Fecha:dd/MM/yyyy},{clase.Cupo}");
                }
            }
        }
    }
}

