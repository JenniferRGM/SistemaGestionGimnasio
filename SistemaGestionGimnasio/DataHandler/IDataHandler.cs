
using System.Collections.Generic;

namespace SistemaGestionGimnasio.DataHandler
{
    /// <summary>
    /// Interfaz para definir las operaciones de manejo de datos en archivos.
    /// Proporciona una abstracción para realizar operaciones como lectura, escritura, eliminación y manipulación de líneas.
    /// </summary>
    public interface IDataHandler
    {
        /// <summary>
        /// Verifica si un archivo existe en la ruta especificada.
        /// </summary>
        /// <param name="filePath">Ruta del archivo a verificar.</param>
        /// <returns>True si el archivo existe, false en caso contrario.</returns>
        bool FileExists(string filePath);

        /// <summary>
        /// Lee todas las líneas de un archivo.
        /// </summary>
        /// <param name="filePath">Ruta del archivo a leer.</param>
        /// <returns>Arreglo de strings que contiene todas las líneas del archivo.</returns>
        string[] ReadAllLines(string filePath);

        /// <summary>
        /// Escribe un conjunto de líneas en un archivo, sobrescribiendo su contenido actual.
        /// </summary>
        /// <param name="filePath">Ruta del archivo.</param>
        /// <param name="lines">Líneas a escribir en el archivo.</param>
        void WriteAllLines(string filePath, string[] lines);

        /// <summary>
        /// Agrega múltiples líneas al final de un archivo.
        /// </summary>
        /// <param name="filePath">Ruta del archivo.</param>
        /// <param name="lines">Líneas a agregar.</param>
        void AppendLines(string filePath, string[] lines);

        /// <summary>
        /// Agrega una línea al final de un archivo.
        /// </summary>
        /// <param name="filePath">Ruta del archivo.</param>
        /// <param name="line">Línea a agregar.</param>
        void AppendLine(string filePath, string line);

        /// <summary>
        /// Elimina un archivo en la ruta especificada.
        /// </summary>
        /// <param name="filePath">Ruta del archivo a eliminar.</param>
        void DeleteFile(string filePath);

        /// <summary>
        /// Mueve un archivo de una ubicación a otra.
        /// </summary>
        /// <param name="sourcePath">Ruta de origen del archivo.</param>
        /// <param name="destinationPath">Ruta de destino del archivo.</param>
        void MoveFile(string sourcePath, string destinationPath);

        /// <summary>
        /// Devuelve una enumeración de líneas de un archivo.
        /// Ideal para procesar archivos grandes sin cargarlos completamente en memoria.
        /// </summary>
        /// <param name="path">Ruta del archivo.</param>
        /// <returns>Enumerable de strings con las líneas del archivo.</returns>
        IEnumerable<string> ReadLines(string path);
    }
}
