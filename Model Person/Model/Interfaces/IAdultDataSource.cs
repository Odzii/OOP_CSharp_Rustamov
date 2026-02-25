namespace Model.Interfaces
{
    //TODO: XML +
    /// <summary>
    /// Источник данных, необходимых для генерации/создания <see cref="Adult"/>:
    /// сведения о местах выдачи паспорта и о местах работы.
    /// </summary>
    public interface IAdultDataSource
    {
        /// <summary>
        /// Получает список вариантов "кем выдан паспорт".
        /// </summary>
        /// <value>
        /// Непустой список строк с названиями мест выдачи паспорта
        /// </value>
        IReadOnlyList<string> PassportsIssuedBy 
        { 
            get; 
        }

        /// <summary>
        /// Получает список вариантов мест работы.
        /// </summary>
        /// <value>
        /// Непустой список строк с названиями мест работы.
        /// </value>
        IReadOnlyList<string> WorkplaceNames 
        { 
            get; 
        }
    }
}
