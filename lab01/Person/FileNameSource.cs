using System;
using System.Collections.Generic;

namespace LabFirst
{
    /// <summary>
    /// Источник имён и фамилий, загружающий данные из текстовых файлов.
    /// </summary>
    public sealed class FileNameSource : INameSource
    {
        /// <summary>
        /// Получает список мужских имён.
        /// </summary>
        public IReadOnlyList<string> MaleNames { get; }

        /// <summary>
        /// Получает список женских имён.
        /// </summary>
        public IReadOnlyList<string> FemaleNames { get; }

        /// <summary>
        /// Получает список фамилий.
        /// </summary>
        public IReadOnlyList<string> Surnames { get; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="FileNameSource"/>,
        /// загружая данные по указанным путям.
        /// </summary>
        /// <param name="malePath">Путь к файлу со списком мужских имён.</param>
        /// <param name="femalePath">Путь к файлу со списком женских имён.</param>
        /// <param name="surnamePath">Путь к файлу со списком фамилий.</param>
        /// <exception cref="ArgumentException">
        /// Бросается, если какой-либо путь равен <see langword="null"/>, 
        /// пустой строке или состоит только из пробелов.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Бросается, если какой-либо файл не найден 
        /// либо не содержит ни одной непустой строки.
        /// </exception>
        public FileNameSource(
            string malePath, 
            string femalePath, 
            string surnamePath
        )
        {
            ValidatePath(malePath, nameof(malePath));
            ValidatePath(femalePath, nameof(femalePath));
            ValidatePath(surnamePath, nameof(surnamePath));

            MaleNames = PersonDataReader.ReadNames(malePath);
            FemaleNames = PersonDataReader.ReadNames(femalePath);
            Surnames = PersonDataReader.ReadNames(surnamePath);

            ThrowIfEmpty(MaleNames, malePath, "мужских имён");
            ThrowIfEmpty(FemaleNames, femalePath, "женских имён");
            ThrowIfEmpty(Surnames, surnamePath, "фамилий");
        }

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

        private static void ThrowIfEmpty(
            IReadOnlyList<string> items, 
            string path, 
            string description
        )
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException(
                    $"Файл со списком {description} пустой или не найден: " +
                    $"\"{path}\"."
                );
            }
        }
    }
}
