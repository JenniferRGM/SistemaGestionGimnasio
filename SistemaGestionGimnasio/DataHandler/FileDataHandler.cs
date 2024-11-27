using System;
using System.Collections.Generic;
using System.IO;

namespace SistemaGestionGimnasio.DataHandler
{
    public class FileDataHandler : IDataHandler
    {
        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public string[] ReadAllLines(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        public void WriteAllLines(string filePath, string[] lines)
        {
            File.WriteAllLines(filePath, lines);
        }

        public void AppendLines(string filePath, string[] lines)
        {
            File.AppendAllLines(filePath, lines);
        }

        public void DeleteFile(string filePath)
        {
            if (FileExists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public void MoveFile(string sourcePath, string destinationPath)
        {
            if (FileExists(sourcePath))
            {
                File.Move(sourcePath, destinationPath);
            }
        }

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

    }
}




