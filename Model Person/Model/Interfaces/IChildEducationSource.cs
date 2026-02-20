namespace Model.Interfaces
{
    /// <summary>
    /// Источник данных, необходимых для задания места обучения <see cref="Child"/>
    /// списки детских садов и школ.
    /// </summary>
    public interface IChildEducationSource
    {
        /// <summary>
        /// Получает список вариантов детских садов.
        /// </summary>
        IReadOnlyList<string> KinderGardens 
        { 
            get; 
        }

        /// <summary>
        /// Получает список вариантов школ.
        /// </summary>
        IReadOnlyList<string> Schools 
        { 
            get; 
        }
    }
}
