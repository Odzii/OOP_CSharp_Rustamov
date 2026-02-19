namespace Model.Common
{
    /// <summary>
    /// Класс хранит пороговые значения возраста
    /// для классов 
    /// <see cref="Person"/>, 
    /// <see cref="Adult"/>, 
    /// <see cref="Child"/>
    /// А также ограничения по длине цифр серии и номера паспорта
    /// </summary>
    internal class Limits
    {
        /// <summary>
        /// Минимально допустимый возраст для 
        /// <see cref="Person"/>.
        /// </summary>
        public const int PersonMinAge = 0;
        /// <summary>
        ///  Максимально допустимый возраст для
        ///  <see cref="Adult"/>.
        /// </summary>
        public const int PersonMaxAge = 123;
        /// <summary>
        /// Минимально допустимый возрастр для
        /// <see cref="Adult"/>.
        /// </summary>
        public const int AdultMinAge = 18;
        /// <summary>
        /// Максимально допустимый возраст для
        /// <see cref="Child"/>.
        /// </summary>
        public const int ChildMaxAge = AdultMinAge - 1;
        /// <summary>
        /// Длина номера паспорта РФ
        /// </summary>
        public const int LenghtNumbers = 6;
        /// <summary>
        /// Длина серии паспорта РФ
        /// </summary>
        public const int LengthSeries = 4;
    }
}
