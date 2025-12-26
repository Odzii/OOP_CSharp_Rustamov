using System;
using System.IO;
using System.Linq;
using System.Text;

namespace LabFirst
{
    /// <summary>
    /// Содержит вспомогательные методы для чтения данных о людях из текстовых файлов.
    /// </summary>
    internal static class PersonDataReader
    {
        public static string[] ReadNames(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                return Array.Empty<string>();
            }    

            return File.ReadAllLines(path, Encoding.UTF8)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToArray();
        }
    }
}