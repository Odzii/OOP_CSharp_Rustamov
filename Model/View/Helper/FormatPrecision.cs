using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Helper
{
    /// <summary>
    /// Хранит форматы точности вывода числовых значений.
    /// </summary>
    internal static class FormatPrecision
    {
        /// <summary>
        /// Формат вывода чисел с шестью знаками после запятой.
        /// </summary>
        public const string Large = "F6";

        /// <summary>
        /// Формат вывода чисел с двумя знаками после запятой.
        /// </summary>
        public const string Short = "F2";
    }
}
