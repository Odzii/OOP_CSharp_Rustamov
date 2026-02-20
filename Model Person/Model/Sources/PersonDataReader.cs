using System.Text;

namespace Model.Sources
{
    /// <summary>
    /// Содержит вспомогательные методы для чтения данных о людях 
    /// из текстовых файлов.
    /// </summary>
    internal static class PersonDataReader
    {
        /// <summary>
        /// Считывает список строк из UTF-8 файла, 
        /// отбрасывая пустые и пробельные строки.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <returns>
        /// Массив непустых строк. 
        /// Если путь пустой/пробельный или файл не существует, 
        /// возвращается пустой массив.
        /// </returns>
        public static string[] ReadNames(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                throw new ArgumentException(
                    "Путь к файлу не может быть пустым, " +
                    "состоять только из пробелов или быть null.",
                    path
                );
            }

            var result = new List<string>();

            foreach (string line in File.ReadLines(path, Encoding.UTF8))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                result.Add(line.Trim());
            }

            return result.ToArray();
        }
    }
}
