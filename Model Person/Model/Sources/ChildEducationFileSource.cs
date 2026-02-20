namespace Model.Sources
{
    /// <summary>
    /// Источник данных об образовании <see cref="Child"/>, 
    /// загружающий их из файлов.
    /// </summary>
    public sealed class ChildEducationFileSource : IChildEducationSource
    {
        /// <summary>
        /// Список вариантов детских садов.
        /// </summary>
        public IReadOnlyList<string> KinderGardens
        {
            get;
        }

        /// <summary>
        /// Список вариантов школ.
        /// </summary>
        public IReadOnlyList<string> Schools
        {
            get;
        }

        /// <summary>
        /// Создаёт источник данных об образовании ребёнка из файлов.
        /// </summary>
        /// <param name="kinderGardensPath">
        /// Путь к файлу со списком детских садов.
        /// </param>
        /// <param name="schoolsPath">
        /// Путь к файлу со списком школ.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Если любой путь пустой, состоит из пробелов или равен null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Если файл не найден или не содержит непустых строк.
        /// </exception>
        public ChildEducationFileSource(
            string kinderGardensPath,
            string schoolsPath
        )
        {
            KinderGardens = FileSourceLoader.LoadRequired(
                kinderGardensPath,
                "детских садов",
                nameof(kinderGardensPath)
            );
            Schools = FileSourceLoader.LoadRequired(
                schoolsPath,
                "школ",
                nameof(schoolsPath)
            );
        }
    }
}