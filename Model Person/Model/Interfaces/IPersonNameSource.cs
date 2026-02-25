namespace Model.Interfaces
{
    
    /// <summary>
    /// Источник данных с именами и фамилиями для создания <see cref="Person"/>.
    /// Предоставляет отдельные списки мужских и женских имён, 
    /// а также общий список фамилий.
    /// </summary>
    public interface IPersonNameSource
    {
        /// <summary>
        /// Получает список мужских имён.
        /// </summary>
        /// <value>
        /// Непустой список строк с мужскими именами.
        /// </value>
        IReadOnlyList<string> MaleNames 
        {
            get; 
        }

        /// <summary>
        /// Получает список женских имён.
        /// </summary>
        /// <value>
        /// Непустой список строк с женскими именами.
        /// </value>
        IReadOnlyList<string> FemaleNames 
        { 
            get; 
        }

        /// <summary>
        /// Получает список фамилий.
        /// </summary>
        /// <value>
        /// Непустой список строк с фамилиями.
        /// </value>
        IReadOnlyList<string> Surnames 
        {
            get; 
        }
    }
}
