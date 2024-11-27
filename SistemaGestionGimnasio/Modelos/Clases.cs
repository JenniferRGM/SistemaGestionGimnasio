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
        public string Horario { get; set; }
        public string Entrenador { get; set; }
        public int Cupo { get; set; }



        public Clases(string nombre, DateTime fecha, string horario, string entrenador, int cupo)
        {
            Nombre = nombre;
            Fecha = fecha;
            Horario = horario;
            Entrenador = entrenador;
            Cupo = cupo;


        }

        // Método para cargar clases desde el archivo
        public static List<string> CargarClasesDesdeArchivo(string rutaArchivo)
        {
            List<string> clasesDisponibles = new List<string>();

            if (!File.Exists(rutaArchivo))
            {
                return clasesDisponibles;
            }

            var lineas = File.ReadAllLines(rutaArchivo).Skip(1);

            foreach (var linea in lineas)
            {
                string[] datos = linea.Split(',');

                if (datos.Length >= 5)
                {
                    string nombre = datos[0].Trim();
                    string fecha = datos[1].Trim();
                    string horario = datos[2].Trim();
                    string entrenador = datos[3].Trim();
                    int cupo = int.Parse(datos[4].Trim());

                    string claseTexto = $"{nombre} - {fecha} - {horario} - {entrenador} (Cupo: {cupo})";
                    clasesDisponibles.Add(claseTexto);
                }
            }

            return clasesDisponibles;
        }
        // Método para reservar una clase
        public static void ReservarClase(string rutaArchivo, string nombreClase, string horarioClase, string entrenadorClase, string fechaClase)
        {
            if (!File.Exists(rutaArchivo))
            {
                throw new FileNotFoundException("El archivo de actividades no existe.");
            }

            var lineas = File.ReadAllLines(rutaArchivo).ToList();
            bool claseEncontrada = false;

            for (int i = 1; i < lineas.Count; i++) // Saltar encabezado
            {
                var datos = lineas[i].Split(',');

                if (datos.Length >= 5)
                {
                    // Normalizar datos del archivo
                    string nombreArchivo = datos[0].Trim().ToLower();
                    string fechaArchivo = datos[1].Trim();
                    string horarioArchivo = datos[2].Trim();
                    string horarioInicialArchivo = horarioArchivo.Split('-')[0].Trim();
                    string entrenadorArchivo = datos[3].Trim().ToLower();

                    Console.WriteLine($"Comparando: nombreArchivo={nombreArchivo}, fechaArchivo={fechaArchivo}, horarioInicialArchivo={horarioInicialArchivo}, entrenadorArchivo={entrenadorArchivo}");

                    // Comparación normalizada
                    if (nombreArchivo == nombreClase &&
                        fechaArchivo == fechaClase &&
                        horarioInicialArchivo.StartsWith(horarioClase) && // Validar prefijo de hora
                        entrenadorArchivo == entrenadorClase)
                    {
                        int cupo = int.Parse(datos[4].Trim());
                        if (cupo > 0)
                        {
                            // Reducir el cupo y actualizar la línea
                            cupo--;
                            datos[4] = cupo.ToString();
                            lineas[i] = string.Join(",", datos);
                            claseEncontrada = true;

                            // Registrar reserva
                            GuardarReserva("reservas.csv", nombreClase, fechaClase, horarioArchivo, entrenadorClase);
                            break;
                        }
                        else
                        {
                            throw new InvalidOperationException("Cupo lleno. No se puede realizar la reserva.");
                        }
                    }
                }
            }

            if (!claseEncontrada)
            {
                throw new KeyNotFoundException("Clase no encontrada. Verifica los datos seleccionados.");
            }

            File.WriteAllLines(rutaArchivo, lineas);
        }


        // Método para guardar una reserva en el archivo reservas.csv
        private static void GuardarReserva(string rutaReservas, string nombreClase, string fechaClase, string horarioClase, string entrenadorClase)
        {
            if (!File.Exists(rutaReservas))
            {
                File.WriteAllText(rutaReservas, "Nombre,Fecha,Horario,Entrenador\n"); // Crear archivo con encabezado
            }

            string nuevaReserva = $"{nombreClase},{fechaClase},{horarioClase},{entrenadorClase}";
            File.AppendAllText(rutaReservas, nuevaReserva + Environment.NewLine);
        }
    }
}





