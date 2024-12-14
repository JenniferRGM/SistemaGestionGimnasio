using System;
using System.Collections.Generic;
using System.IO;

namespace SistemaGestionGimnasio.DataHandler
{
    /// <summary>
    /// Clase para manejar operaciones de archivos, implementa la interfaz IDataHandler.
    /// Proporciona métodos comunes para trabajar con archivos, como lectura, escritura, y manejo de líneas.
    /// </summary>
    public class FileDataHandler : IDataHandler
    {
        /// <summary>
        /// Verifica si un archivo existe en la ruta especificada.
        /// </summary>
        /// <param name="filePath">Ruta del archivo a verificar.</param>
        /// <returns>True si el archivo existe, false en caso contrario.</returns>
        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        /// <summary>
        /// Verifica si un archivo existe en la ruta especificada.
        /// </summary>
        /// <param name="filePath">Ruta del archivo a verificar.</param>
        /// <returns>True si el archivo existe, false en caso contrario.</returns>
        public string[] ReadAllLines(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        /// <summary>
        /// Escribe un conjunto de líneas en un archivo, sobrescribiendo su contenido actual.
        /// </summary>
        /// <param name="filePath">Ruta del archivo.</param>
        /// <param name="lines">Líneas a escribir en el archivo.</param>
        public void WriteAllLines(string filePath, string[] lines)
        {
            File.WriteAllLines(filePath, lines);
        }

        /// <summary>
        /// Agrega múltiples líneas al final de un archivo.
        /// </summary>
        /// <param name="filePath">Ruta del archivo.</param>
        /// <param name="lines">Líneas a agregar.</param>
        public void AppendLines(string filePath, string[] lines)
        {
            File.AppendAllLines(filePath, lines);
        }

        /// <summary>
        /// Elimina un archivo si existe en la ruta especificada.
        /// </summary>
        /// <param name="filePath">Ruta del archivo a eliminar.</param>
        public void DeleteFile(string filePath)
        {
            if (FileExists(filePath))
            {
                File.Delete(filePath);
            }
        }

        /// <summary>
        /// Mueve un archivo de una ubicación a otra.
        /// </summary>
        /// <param name="sourcePath">Ruta de origen del archivo.</param>
        /// <param name="destinationPath">Ruta de destino del archivo.</param>
        public void MoveFile(string sourcePath, string destinationPath)
        {
            if (FileExists(sourcePath))
            {
                File.Move(sourcePath, destinationPath);
            }
        }

        /// <summary>
        /// Agrega una línea al final de un archivo.
        /// </summary>
        /// <param name="path">Ruta del archivo.</param>
        /// <param name="line">Línea a agregar.</param>
        public void AppendLine(string path, string line)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                throw new IOException($"Error escribiendo en el archivo: {ex.Message}");
            }
        }

        /// <summary>
        /// Devuelve una enumeración de líneas de un archivo.
        /// Ideal para archivos grandes donde no se quiere cargar todo en memoria.
        /// </summary>
        /// <param name="path">Ruta del archivo.</param>
        /// <returns>Enumerable de strings con las líneas del archivo.</returns>
        public IEnumerable<string> ReadLines(string path)
        {
            return File.ReadLines(path);
        }

    }
}
