using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabFirst
{
    /// <summary>
    /// Класс хранит пороговые значения возраста
    /// для классов 
    /// <see cref="Person"/>, 
    /// <see cref="Adult"/>, 
    /// <see cref="Child"/>
    /// </summary>
    internal class AgeRules
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
    }
}
