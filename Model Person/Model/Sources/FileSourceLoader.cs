namespace Model.Sources
{
    /// <summary>
    /// Вспомогательный класс для загрузки списков строк из файлов.
    /// </summary>
    public static class FileSourceLoader
    {
        /// <summary>
        /// Проверяет корректность пути к файлу.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <param name="paramName">
        /// Имя параметра для исключения.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Если <paramref name="path"/> пустой, из пробелов или равен null.
        /// </exception>
        private static void ValidatePath(string path, string paramName)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException(
                    "Путь к файлу не может быть пустым, " +
                    "состоять только из пробелов или быть null.",
                    paramName
                );
            }
        }

        /// <summary>
        /// Загружает непустой список строк из файла.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <param name="description">Описание списка для текста ошибки.</param>
        /// <param name="paramName">Имя параметра, содержащего путь.</param>
        /// <returns>Список строк, загруженный из файла.</returns>
        /// <exception cref="ArgumentException">
        /// Если <paramref name="path"/> пустой, из пробелов или равен null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Если файл не найден или не содержит ни одной непустой строки.
        /// </exception>
        internal static IReadOnlyList<string> LoadRequired(
            string path,
            string description,
            string paramName
        )
        {
            ValidatePath(path, paramName);

            IReadOnlyList<string> items = PersonDataReader.ReadNames(path);

            if (items.Count == 0)
            {
                throw new InvalidOperationException(
                    $"Файл со списком {description} пустой или не найден: " +
                    $"\"{path}\"."
                );
            }

            return items;
        }
    }
}