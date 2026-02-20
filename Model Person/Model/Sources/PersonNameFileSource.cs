namespace Model.Sources
{
    /// <summary>
    /// Источник имён и фамилий для <see cref="Person"/>, 
    /// читающий данные из файлов.
    /// </summary>
    public sealed class PersonNameFileSource : IPersonNameSource
    {
        /// <summary>
        /// Список мужских имён.
        /// </summary>
        public IReadOnlyList<string> MaleNames 
        { 
            get; 
        }

        /// <summary>
        /// Список женских имён.
        /// </summary>
        public IReadOnlyList<string> FemaleNames 
        {
            get; 
        }

        /// <summary>
        /// Список фамилий.
        /// </summary>
        public IReadOnlyList<string> Surnames 
        { 
            get; 
        }

        /// <summary>
        /// Создаёт источник имён и фамилий, загружая данные из файлов.
        /// </summary>
        /// <param name="malePath">Путь к файлу со списком мужских имён.</param>
        /// <param name="femalePath">Путь к файлу со списком женских имён.</param>
        /// <param name="surnamePath">Путь к файлу со списком фамилий.</param>
        /// <exception cref="ArgumentException">
        /// Если любой путь пустой, из пробелов или равен null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Если файл не найден или не содержит непустых строк.
        /// </exception>
        public PersonNameFileSource(
            string malePath, 
            string femalePath, 
            string surnamePath
        )
        {
            MaleNames = FileSourceLoader.LoadRequired(
                malePath,
                "мужских имён",
                nameof(malePath)
            );
            FemaleNames = FileSourceLoader.LoadRequired(
                femalePath,
                "женских имён",
                nameof(femalePath)
            );
            Surnames = FileSourceLoader.LoadRequired(
                surnamePath,
                "фамилий",
                nameof(surnamePath)
            );
        }
    }
}