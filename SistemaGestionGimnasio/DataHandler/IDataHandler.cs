
using System.Collections.Generic;

namespace SistemaGestionGimnasio.DataHandler
{
    public interface IDataHandler
    {
        bool FileExists(string filePath);
        string[] ReadAllLines(string filePath);
        void WriteAllLines(string filePath, string[] lines);
        void AppendLines(string filePath, string[] lines);
        void DeleteFile(string filePath);
        void MoveFile(string sourcePath, string destinationPath);
    }
}
