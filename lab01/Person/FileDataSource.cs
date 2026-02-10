using System;
using System.Collections.Generic;

namespace LabFirst
{
    /// <summary>
    /// Источник имён и фамилий, загружающий данные из текстовых файлов.
    /// </summary>
    public sealed class FileDataSource : IPersonNameSource, IAdultDataSource, IChildEducationSource
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

        //TODO: XML
        /// <summary>
        ///  
        /// </summary>
        public IReadOnlyList<string> WorkplaceNames { get; }

        //TODO: XML
        /// <summary>
        /// 
        /// </summary>
        public IReadOnlyList<string> PassportsIssuedBy { get; }


        /// <summary>
        /// Получает список мест образования
        /// </summary>
        public IReadOnlyList<string> KinderGardens { get; }
        
        /// <summary>
        /// 
        /// </summary>
        public IReadOnlyList<string> Schools { get; }



        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="FileDataSource"/>,
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
        public FileDataSource(
            string malePath, 
            string femalePath, 
            string surnamePath,
            string passportsIssuedByPath,
            string workplaceNamesPath,
            string kinderGardens,
            string schools

        )
        {
            MaleNames = LoadRequired(malePath, "мужских имён");
            FemaleNames = LoadRequired(femalePath, "женских имён");
            Surnames = LoadRequired(surnamePath, "фамилий");

            PassportsIssuedBy = LoadRequired(
                passportsIssuedByPath, 
                "мест выдачи паспорта"
            );

            WorkplaceNames = LoadRequired(
                workplaceNamesPath, 
                "мест работы"
            );
            KinderGardens = LoadRequired(
                kinderGardens, 
                "дестких садов"
            );
            Schools = LoadRequired(schools, "школ");
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

        private static IReadOnlyList<string> LoadRequired(
            string path, 
            string description
        )
        {
            ValidatePath(path, nameof(path));

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
