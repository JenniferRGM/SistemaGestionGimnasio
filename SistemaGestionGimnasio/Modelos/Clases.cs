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

        public static List<string> CargarClasesDesdeArchivo(string rutaArchivo)
        {
            List<string> clasesDisponibles = new List<string>();

            if (!File.Exists(rutaArchivo))
            {
                return clasesDisponibles;
            }

            var lineas = File.ReadAllLines(rutaArchivo).Skip(1); // Saltar encabezado

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
                    string nombreArchivo = datos[0].Trim();
                    string fechaArchivo = datos[1].Trim();
                    string horarioArchivo = datos[2].Trim();
                    string entrenadorArchivo = datos[3].Trim();

                    // Agrega un mensaje de depuración para verificar las comparaciones
                    Console.WriteLine($"Comparando: Nombre={nombreArchivo}, Fecha={fechaArchivo}, Horario={horarioArchivo}, Entrenador={entrenadorArchivo}");

                    if (nombreArchivo == nombreClase &&
                        fechaArchivo == fechaClase &&
                        horarioArchivo == horarioClase &&
                        entrenadorArchivo == entrenadorClase)
                    {
                        int cupo = int.Parse(datos[4].Trim());
                        if (cupo > 0)
                        {
                            cupo--;
                            datos[4] = cupo.ToString(); // Actualizar cupo en línea
                            lineas[i] = string.Join(",", datos); // Actualizar la línea
                            claseEncontrada = true;
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

            // Escribir las líneas actualizadas de vuelta al archivo
            File.WriteAllLines(rutaArchivo, lineas);
        }
    }
}




