namespace Model.Sources
{
    /// <summary>
    /// Источник данных для <see cref="Adult"/>, 
    /// загружающий данные из файлов.
    /// </summary>
    public sealed class AdultFileSource : IAdultDataSource
    {
        /// <summary>
        /// Список вариантов мест работы.
        /// </summary>
        public IReadOnlyList<string> WorkplaceNames
        {
            get;
        }

        /// <summary>
        /// Список вариантов "кем выдан паспорт".
        /// </summary>
        public IReadOnlyList<string> PassportsIssuedBy
        {
            get;
        }

        /// <summary>
        /// Создаёт источник данных для <see cref="Adult"/> из файлов.
        /// </summary>
        /// <param name="passportsIssuedByPath">
        /// Путь к файлу со списком мест выдачи паспорта.
        /// </param>
        /// <param name="workplaceNamesPath">
        /// Путь к файлу со списком мест работы.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Если любой путь пустой, состоит из пробелов или равен null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Если файл не найден или не содержит непустых строк.
        /// </exception>
        public AdultFileSource(string passportsIssuedByPath, string workplaceNamesPath)
        {
            PassportsIssuedBy = FileSourceLoader.LoadRequired(
                passportsIssuedByPath,
                "мест выдачи паспорта",
                nameof(passportsIssuedByPath)
            );
            WorkplaceNames = FileSourceLoader.LoadRequired(
                workplaceNamesPath,
                "мест работы",
                nameof(workplaceNamesPath)
            );
        }
    }
}
